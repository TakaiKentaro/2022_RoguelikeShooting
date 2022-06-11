using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class WeaponSword : MonoBehaviour, IPool
{

    [Header("�X�e�[�^�X")]
    [Tooltip("�U����")] public int _attackDmg = 1;
    [Tooltip("�ړ����x")] public float _weaponSpeed;
    [Tooltip("��")] public int _weaponNum = 1;
    [Tooltip("���x��")] public int _weaponLevel;
    [Tooltip("�C���^�[�o��")]public float _timer = 3;

    [Tooltip("�����锻��")] bool _check = true;

    [Tooltip("Player")] PlayerController _player;
    [Tooltip("RigidBody")] Rigidbody _rb;

    Enemy _enemy;
    public bool Waiting { get; set; }

    /// <summary>
    /// �������̏�����. Start�֐�
    /// </summary>
    /// <param name="parent">�eObject</param>
    public void SetUp(Transform parent)
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        _rb = GetComponent<Rigidbody>();
        LevelSet(_weaponLevel);

        gameObject.SetActive(false);
    }

    /// <summary>
    /// Use�����ۂ̏�����. Start�֐�
    /// </summary>
    public void IsUseSetUp()
    {
        _timer = 0;

        gameObject.transform.position = new Vector3(_player.transform.position.x, 1.5f, _player.transform.position.z);
        gameObject.transform.rotation = _player.transform.rotation;

        gameObject.SetActive(true);
    }

    /// <summary>
    /// �g�p���̏���. Update�֐� true���Ԃ������葱����
    /// </summary>
    /// <returns></returns>
    public bool Execute()
    {
        _rb.velocity = this.transform.forward * _weaponSpeed;

        return _check;
    }

    /// <summary>
    /// Execute����������ۂ̏���, Destroy�֐�
    /// </summary>
    public void Delete()
    {
        _check = true;
        gameObject.SetActive(false);
    }

    /// <summary>
    /// �����鏈��
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Debug.Log("�G�ɓ�������");
            enemy.OnDamage(_player._playerPower + _attackDmg);
            //_check = false;
        }
    }

    /// <summary>
    /// ����̃��x���ɉ���������
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
