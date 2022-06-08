using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// エネミーのスクリプト
/// </summary>
public class Enemy : MonoBehaviour, IPool
{
    

    [Header("ステータス")]
    [SerializeField, Tooltip("エネミーの体力")] float _enemyHp;
    [SerializeField, Tooltip("エネミーの攻撃力")] float _enemyPower;
    [SerializeField, Tooltip("エネミーのスピード")] float _enemySpeed;

    [Header("ドロップするクリスタル")]
    [SerializeField, Tooltip("クリスタル")] GameObject _crystal;

    [Tooltip("NavMeshAgent")] NavMeshAgent _agent;
    [Tooltip("プレイヤー")] GameObject _player;

    [Tooltip("時間判定")] float _timer;
    [Tooltip("画面外に出たか判定")] bool _visibleCheck;

    public bool Waiting { get; set; }

    /// <summary>
    /// 生成時の初期化. Start関数
    /// </summary>
    /// <param name="parent">親Object</param>
    public void SetUp(Transform parent)
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player");

        _agent.speed = _enemySpeed;

        gameObject.SetActive(false);
        Debug.Log(_player);
    }

    /// <summary>
    /// Useした際の初期化. Start関数
    /// </summary>
    public void IsUseSetUp()
    {
        _timer = 0;
        gameObject.SetActive(true);
    }

    /// <summary>
    /// 使用中の処理. Update関数
    /// </summary>
    /// <returns></returns>
    public bool Execute()
    {
        _timer += Time.deltaTime;
        Debug.Log(_timer);
        _agent.destination = _player.transform.position;

        return true;
    }

    /// <summary>
    /// Executeがおわった際の処理, Destroy関数
    /// </summary>
    public void Delete()
    {
        Instantiate(_crystal,gameObject.transform.position,Quaternion.identity);
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 画面外に出たら一定時間後に一度消える
    /// </summary>
    void OnBecameVisible()
    {
        if (_timer < 10) _visibleCheck = false;
        else _visibleCheck = true;
    }

    /// <summary>
    /// プレイヤー・武器の当たった時の処理
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("プレイヤーに当たった");
            _player.GetComponent<PlayerController>()._playerHp -= _enemyPower;
        }
    }
}
