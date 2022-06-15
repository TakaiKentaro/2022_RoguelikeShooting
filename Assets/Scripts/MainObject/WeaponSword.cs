using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
public class WeaponSword : MonoBehaviour, IPool
{

    [Header("ステータス")]
    [Tooltip("攻撃力")] static public int _attackDmg = 2;
    [Tooltip("移動速度")] public float _weaponSpeed;
    [Tooltip("インターバル")] public float _timer = 3;
    [SerializeField, Tooltip("出る角度")] float _angle = 0;

    [Tooltip("消える判定")] bool _check = true;

    [Tooltip("Player")] PlayerController _player;
    [Tooltip("RigidBody")] Rigidbody _rb;

    Enemy _enemy;
    public bool Waiting { get; set; }

    /// <summary>
    /// 生成時の初期化. Start関数
    /// </summary>
    /// <param name="parent">親Object</param>
    public void SetUp(Transform parent)
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        _rb = GetComponent<Rigidbody>();
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Useした際の初期化. Start関数
    /// </summary>
    public void IsUseSetUp()
    {
        _timer = 0;

        gameObject.transform.position = new Vector3(_player.transform.position.x, 1.5f, _player.transform.position.z);;
        gameObject.transform.rotation = _player.transform.rotation;
        var t = transform.localEulerAngles;
        t.y += _angle;
        transform.localEulerAngles = t;

        gameObject.SetActive(true);

        StartCoroutine(Destroy());
    }

    /// <summary>
    /// 使用中の処理. Update関数 trueが返る限り周り続ける
    /// </summary>
    /// <returns></returns>
    public bool Execute()
    {
        _rb.velocity = this.transform.forward * _weaponSpeed;

        return _check;
    }

    /// <summary>
    /// Executeがおわった際の処理, Destroy関数
    /// </summary>
    public void Delete()
    {
        _check = true;
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 当たる処理
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Debug.Log("敵に当たった");
            enemy.OnDamage(+_attackDmg);
            //_check = false;
        }
    }

    /// <summary>
    /// 時間経過で消える処理
    /// </summary>
    /// <returns></returns>
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(10);
        _check = false;
    }
}
