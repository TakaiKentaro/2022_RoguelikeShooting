using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// �G�l�~�[�̃X�N���v�g
/// </summary>
public class Enemy : MonoBehaviour, IPool
{
    [Header("�X�e�[�^�X")]
    [SerializeField, Tooltip("�G�l�~�[�̗̑�")] byte _enemyHp;
    [SerializeField, Tooltip("�G�l�~�[�̍U����")] byte _enemyPower;
    [SerializeField, Tooltip("�G�l�~�[�̃X�s�[�h")] float _enemySpeed;

    [Header("�h���b�v����N���X�^��")]
    [SerializeField, Tooltip("�N���X�^��")] GameObject _crystal;

    [Tooltip("NavMeshAgent")] NavMeshAgent _agent;
    [Tooltip("�v���C���[")] GameObject _player;

    [Tooltip("���Ԕ���")] float _timer;
    [Tooltip("��ʊO�ɏo��������")] bool _visibleCheck;

    public bool Waiting { get; set; }

    /// <summary>
    /// �������̏�����. Start�֐�
    /// </summary>
    /// <param name="parent">�eObject</param>
    public void SetUp(Transform parent)
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player");

        _agent.speed = _enemySpeed;
    }

    /// <summary>
    /// Use�����ۂ̏�����. Start�֐�
    /// </summary>
    public void IsUseSetUp()
    {
        gameObject.SetActive(true);
    }

    /// <summary>
    /// �g�p���̏���. Update�֐�
    /// </summary>
    /// <returns></returns>
    public bool Execute()
    {
        _agent.destination = _player.transform.position;
        return _visibleCheck;
    }

    /// <summary>
    /// Execute����������ۂ̏���, Destroy�֐�
    /// </summary>
    public void Delete()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// ��ʊO�ɏo�����莞�Ԍ�Ɉ�x������
    /// </summary>
    void OnBecameVisible()
    {
        _timer += Time.deltaTime;

        if (_timer < 10) _visibleCheck = false;
        else _visibleCheck = true;
    }
}
