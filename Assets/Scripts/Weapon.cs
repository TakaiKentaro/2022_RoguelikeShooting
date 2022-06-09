using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public abstract class Weapon : MonoBehaviour, IPool
{

    [Header("�X�e�[�^�X")]
    [Tooltip("�U����")] public int _attackDmg = 1;
    [Tooltip("�ړ����x")] public float _weponSpeed = 1;
    [Tooltip("��")] public int _weponNum = 1;
    [SerializeField, Tooltip("�C���^�[�o��")] float _timer;

    [Tooltip("���˂̈ʒu")] Vector3 _shootVec;

    [Tooltip("�����锻��")] bool _check = true;

    [Tooltip("PLayer")] public PlayerController _player;

    Enemy _enemy;
    public bool Waiting { get; set; }

    /// <summary>
    /// �������̏�����. Start�֐�
    /// </summary>
    /// <param name="parent">�eObject</param>
    public void SetUp(Transform parent)
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Use�����ۂ̏�����. Start�֐�
    /// </summary>
    public void IsUseSetUp()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        _timer = 0;
        _shootVec.Normalize();
    }

    /// <summary>
    /// �g�p���̏���. Update�֐� true���Ԃ������葱����
    /// </summary>
    /// <returns></returns>
    public bool Execute()
    {
        transform.position += _shootVec * _weponSpeed * Time.deltaTime;

        return _check;
    }

    /// <summary>
    /// Execute����������ۂ̏���, Destroy�֐�
    /// </summary>
    public void Delete()
    {
        gameObject?.SetActive(false);
    }

    /// <summary>
    /// �����鏈��
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
    /// �G�ɓ����������̏���
    /// </summary>
    int Damage(int Hp)
    {
        int pl = _player._playerPower - _attackDmg;
        int enemyHp = Hp - pl;

        return enemyHp;
    }
}
