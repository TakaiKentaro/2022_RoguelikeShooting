using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// �G�l�~�[�̃X�N���v�g
/// </summary>
public class Enemy : MonoBehaviour, IPool
{


    [Header("�X�e�[�^�X")]
    [SerializeField, Tooltip("�G�l�~�[�̗̑�")] public int _enemyHp;
    [Tooltip("�G�l�~�[�̗̑̓Z�[�u")] int _saveEnemyHp;
    [SerializeField, Tooltip("�G�l�~�[�̍U����")] float _enemyPower;
    [SerializeField, Tooltip("�G�l�~�[�̃X�s�[�h")] float _enemySpeed;
    [Tooltip("���x���A�b�v")] float _levelTime = 30;

    [Header("�h���b�v����N���X�^��")]
    [SerializeField, Tooltip("�N���X�^��")] GameObject _crystal;
    [SerializeField, Tooltip("���Ƃ��m��")] int _rnd;

    [Tooltip("NavMeshAgent")] NavMeshAgent _agent;
    [Tooltip("�v���C���[")] GameObject _player;

    [Tooltip("���Ԕ���")] float _timer;
    [Tooltip("��ʊO�ɏo��������")] bool _check = true;

    [Tooltip("CrystalSpowner")] CrystalSpowner _crystalSpowner;

    public bool Waiting { get; set; }

    /// <summary>
    /// �������̏�����. Start�֐�
    /// </summary>
    /// <param name="parent">�eObject</param>
    public void SetUp(Transform parent)
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _crystalSpowner = GameObject.Find("CrystalSpowner").GetComponent<CrystalSpowner>();

        _agent.speed = _enemySpeed;

        gameObject.SetActive(false);
    }

    /// <summary>
    /// Use�����ۂ̏�����. Start�֐�
    /// </summary>
    public void IsUseSetUp()
    {
        _check = true;
        _timer = 0;
        _saveEnemyHp = _enemyHp;
        gameObject.SetActive(true);
    }

    /// <summary>
    /// �g�p���̏���. Update�֐� true���Ԃ������葱����
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
    /// Execute����������ۂ̏���, Destroy�֐�
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
    /// ��ʊO�ɏo�����莞�Ԍ�Ɉ�x������
    /// </summary>
    void OnBecameVisible()
    {
        //_timer = 0;
        //if (_timer > 10) _check = false;
        //else _check = true;
    }

    /// <summary>
    /// ����ɓ����������̏���
    /// </summary>
    /// <param name="damage"></param>
    public void OnDamage(int damage)
    {
        _enemyHp -= damage;
    }

    /// <summary>
    /// �G�l�~�[�̃��x���A�b�v
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
    /// �v���C���[�E����̓����������̏���
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            Debug.Log("�v���C���[�ɓ�������");
            PlayerController._playerHp -= _enemyPower;
        }
    }
}
