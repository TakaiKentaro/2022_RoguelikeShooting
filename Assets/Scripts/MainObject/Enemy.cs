using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// エネミーのスクリプト
/// </summary>
public class Enemy : MonoBehaviour, IPool
{


    [Header("ステータス")]
    [SerializeField, Tooltip("エネミーの体力")] public int _enemyHp;
    [Tooltip("エネミーの体力セーブ")] int _saveEnemyHp;
    [SerializeField, Tooltip("エネミーの攻撃力")] float _enemyPower;
    [SerializeField, Tooltip("エネミーのスピード")] float _enemySpeed;
    [Tooltip("レベルアップ")] float _levelTime = 30;

    [Header("ドロップするクリスタル")]
    [SerializeField, Tooltip("クリスタル")] GameObject _crystal;
    [SerializeField, Tooltip("落とす確率")] int _rnd;

    [Tooltip("NavMeshAgent")] NavMeshAgent _agent;
    [Tooltip("プレイヤー")] GameObject _player;

    [Tooltip("時間判定")] float _timer;
    [Tooltip("画面外に出たか判定")] bool _check = true;

    [Tooltip("CrystalSpowner")] CrystalSpowner _crystalSpowner;

    public bool Waiting { get; set; }

    /// <summary>
    /// 生成時の初期化. Start関数
    /// </summary>
    /// <param name="parent">親Object</param>
    public void SetUp(Transform parent)
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _crystalSpowner = GameObject.Find("CrystalSpowner").GetComponent<CrystalSpowner>();

        _agent.speed = _enemySpeed;

        gameObject.SetActive(false);
    }

    /// <summary>
    /// Useした際の初期化. Start関数
    /// </summary>
    public void IsUseSetUp()
    {
        _check = true;
        _timer = 0;
        _saveEnemyHp = _enemyHp;
        gameObject.SetActive(true);
    }

    /// <summary>
    /// 使用中の処理. Update関数 trueが返る限り周り続ける
    /// </summary>
    /// <returns></returns>
    public bool Execute()
    {
        if (_enemyHp <= 0) _check = false;
        Levelup();
        _timer += Time.deltaTime;
        _agent.destination = _player.transform.position;

        return _check;
    }

    /// <summary>
    /// Executeがおわった際の処理, Destroy関数
    /// </summary>
    public void Delete()
    {
        int rnd = Random.Range(0, _rnd);
        if (rnd != 0) { _crystalSpowner.SpownCrystal(transform); }
        _enemyHp += _saveEnemyHp;
        GameManager.Instance.KillCount();
        _check = true;
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 画面外に出たら一定時間後に一度消える
    /// </summary>
    void OnBecameVisible()
    {
        //_timer = 0;
        //if (_timer > 10) _check = false;
        //else _check = true;
    }

    /// <summary>
    /// 武器に当たった時の処理
    /// </summary>
    /// <param name="damage"></param>
    public void OnDamage(int damage)
    {
        _enemyHp -= damage;
    }

    /// <summary>
    /// エネミーのレベルアップ
    /// </summary>
    public void Levelup()
    {
        float time = GameManager.Instance._gameTimer;

        if(time >= _levelTime)
        {
            _enemyHp *= 2;
            _enemyPower *= 2;
            _levelTime += 30;
        }
    }

    /// <summary>
    /// プレイヤー・武器の当たった時の処理
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            Debug.Log("プレイヤーに当たった");
            PlayerController._playerHp -= _enemyPower;
        }
    }
}
