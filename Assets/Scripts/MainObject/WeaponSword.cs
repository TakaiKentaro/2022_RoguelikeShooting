using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
public class WeaponSword : MonoBehaviour, IPool
{

    [Header("�X�e�[�^�X")]
    [Tooltip("�U����")] static public int _attackDmg = 2;
    [Tooltip("�ړ����x")] public float _weaponSpeed;
    [Tooltip("�C���^�[�o��")] public float _timer = 3;
    [SerializeField, Tooltip("�o��p�x")] float _angle = 0;

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
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Use�����ۂ̏�����. Start�֐�
    /// </summary>
    public void IsUseSetUp()
    {
        _timer = 0;

        gameObject.transform.position = new Vector3(_player.transform.position.x, 1.5f, _player.transform.position.z);;
        gameObject.transform.rotation = _player.transform.rotation;
        var t = transform.localEulerAngles;
        t.y += _angle;
        transform.localEulerAngles = t;

        gameObject.SetActive(true);

        StartCoroutine(Destroy());
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
            enemy.OnDamage(+_attackDmg);
            //_check = false;
        }
    }

    /// <summary>
    /// ���Ԍo�߂ŏ����鏈��
    /// </summary>
    /// <returns></returns>
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(10);
        _check = false;
    }
}
