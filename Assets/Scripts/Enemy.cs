using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// エネミーのスクリプト
/// </summary>
public class Enemy : MonoBehaviour, IPool
{
    [Header("ステータス")]
    [SerializeField, Tooltip("エネミーの体力")] byte _enemyHp;
    [SerializeField, Tooltip("エネミーの攻撃力")] byte _enemyPower;
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
    }

    /// <summary>
    /// Useした際の初期化. Start関数
    /// </summary>
    public void IsUseSetUp()
    {
        gameObject.SetActive(true);
    }

    /// <summary>
    /// 使用中の処理. Update関数
    /// </summary>
    /// <returns></returns>
    public bool Execute()
    {
        _agent.destination = _player.transform.position;
        return _visibleCheck;
    }

    /// <summary>
    /// Executeがおわった際の処理, Destroy関数
    /// </summary>
    public void Delete()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 画面外に出たら一定時間後に一度消える
    /// </summary>
    void OnBecameVisible()
    {
        _timer += Time.deltaTime;

        if (_timer < 10) _visibleCheck = false;
        else _visibleCheck = true;
    }
}
