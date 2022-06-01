using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Enemy�̊��N���X
/// </summary>
public class EnemyController : MonoBehaviour
{
    [Header("�X�e�[�^�X")]
    [SerializeField, Tooltip("�G�l�~�[�̗̑�")] byte _enemyHp;
    [SerializeField, Tooltip("�G�l�~�[�̍U����")] byte _enemyPower;
    [SerializeField, Tooltip("�G�l�~�[�̃X�s�[�h")] float _enemySpeed;

    [Header("�h���b�v����N���X�^��")]
    [SerializeField, Tooltip("�N���X�^��")] GameObject _crystal;

    [Tooltip("NavMeshAgent")] NavMeshAgent _agent;
    [Tooltip("�v���C���[")] GameObject _player;

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
    /// �v���C���[��ǐՂ��鏈��
    /// </summary>
    void TrackingPlayer()
    {
        _agent.destination = _player.transform.position;
    }
}
