using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public abstract class Weapon : MonoBehaviour, IPool
{

    [Header("ステータス")]
    [Tooltip("攻撃力")] public int _attackDmg = 1;
    [Tooltip("移動速度")] public float _weponSpeed = 1;
    [Tooltip("個数")] public int _weponNum = 1;
    [SerializeField, Tooltip("インターバル")] float _timer;

    [Tooltip("発射の位置")] Vector3 _shootVec;

    [Tooltip("消える判定")] bool _check = true;

    [Tooltip("PLayer")] public PlayerController _player;

    Enemy _enemy;
    public bool Waiting { get; set; }

    /// <summary>
    /// 生成時の初期化. Start関数
    /// </summary>
    /// <param name="parent">親Object</param>
    public void SetUp(Transform parent)
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Useした際の初期化. Start関数
    /// </summary>
    public void IsUseSetUp()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        _timer = 0;
        _shootVec.Normalize();
    }

    /// <summary>
    /// 使用中の処理. Update関数 trueが返る限り周り続ける
    /// </summary>
    /// <returns></returns>
    public bool Execute()
    {
        transform.position += _shootVec * _weponSpeed * Time.deltaTime;

        return _check;
    }

    /// <summary>
    /// Executeがおわった際の処理, Destroy関数
    /// </summary>
    public void Delete()
    {
        gameObject?.SetActive(false);
    }

    /// <summary>
    /// 当たる処理
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            int Hp = enemy._enemyHp;
            enemy._enemyHp = Damage(Hp);
        }
    }

    /// <summary>
    /// 敵に当たった時の処理
    /// </summary>
    int Damage(int Hp)
    {
        int pl = _player._playerPower - _attackDmg;
        int enemyHp = Hp - pl;

        return enemyHp;
    }
}
