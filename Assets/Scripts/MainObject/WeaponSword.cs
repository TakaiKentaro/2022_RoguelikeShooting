using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class WeaponSword : MonoBehaviour, IPool
{

    [Header("ステータス")]
    [Tooltip("攻撃力")] public int _attackDmg = 1;
    [Tooltip("移動速度")] public float _weaponSpeed;
    [Tooltip("個数")] public int _weaponNum = 1;
    [Tooltip("レベル")] public int _weaponLevel;
    [Tooltip("インターバル")]public float _timer = 3;

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
        LevelSet(_weaponLevel);

        gameObject.SetActive(false);
    }

    /// <summary>
    /// Useした際の初期化. Start関数
    /// </summary>
    public void IsUseSetUp()
    {
        _timer = 0;

        gameObject.transform.position = new Vector3(_player.transform.position.x, 1.5f, _player.transform.position.z);
        gameObject.transform.rotation = _player.transform.rotation;

        gameObject.SetActive(true);
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
            enemy.OnDamage(_player._playerPower + _attackDmg);
            //_check = false;
        }
    }

    /// <summary>
    /// 武器のレベルに応じた処理
    /// </summary>
    /// <param name="level"></param>
    public void LevelSet(int level)
    {
        switch (level)
        {
            case 1:
                _attackDmg = 1;
                _timer = 3;
                
                _weaponNum = 1;
                break;
            case 2:
                _weaponNum = 2;
                break;
            case 3:
                _timer = 2.5f;
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;
        }
    }
}
