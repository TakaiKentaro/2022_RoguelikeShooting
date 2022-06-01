using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Enemyの基底クラス
/// </summary>
public class EnemyController : MonoBehaviour
{
    [Header("ステータス")]
    [SerializeField, Tooltip("エネミーの体力")] byte _enemyHp;
    [SerializeField, Tooltip("エネミーの攻撃力")] byte _enemyPower;
    [SerializeField, Tooltip("エネミーのスピード")] float _enemySpeed;

    [Header("ドロップするクリスタル")]
    [SerializeField, Tooltip("クリスタル")] GameObject _crystal;

    [Tooltip("NavMeshAgent")] NavMeshAgent _agent;
    [Tooltip("プレイヤー")] GameObject _player;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player");

        _agent.speed = _enemySpeed;
    }

    void Update()
    {
        TrackingPlayer();
    }

    /// <summary>
    /// プレイヤーを追跡する処理
    /// </summary>
    void TrackingPlayer()
    {
        _agent.destination = _player.transform.position;
    }
}
