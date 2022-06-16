using UnityEngine;
using System.Collections;

/// <summary>
/// �v���C���[�N���X
/// </summary>
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("�X�e�[�^�X")]
    [Tooltip("�̗͏��")] public static float _playerHpMaxValue = 100;
    [Tooltip("���݂̗̑�")] public static float _playerHp = 100;
    [SerializeField, Tooltip("�ړ����x")]public static int _playerSpeed = 3;

    [Tooltip("�v���C���[��RigidBody2D")] Rigidbody _rb;
    [Tooltip("�v���C���[�̈ʒu")] Transform _playerPos;

    [Tooltip("�v���C���[�̃A�j���[�^�[")] Animator _anim;

    void Start()
    {
        GameManager.Instance.SetPlayer(this);
        _playerHpMaxValue = 100;
        _playerHp = 100;
        _playerSpeed = 3;
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        StartCoroutine(HealHp());
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerHp <= 0)
        {
            Dead();
        }
        else
        {
            PlayerMove();
        }
    }

    /// <summary>
    /// �v���C���[�̈ړ�
    /// </summary>
    void PlayerMove()
    {

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(h, 0, v);

        dir = Camera.main.transform.TransformDirection(dir);
        dir.y = 0;

        if (dir != Vector3.zero)
        {
            this.transform.forward = dir;
        }

        _rb.velocity = dir.normalized * _playerSpeed + _rb.velocity.y * Vector3.up;

        if (h != 0 || v != 0)
        {
            _anim.SetBool("Run", true);
        }
        else
        {
            _anim.SetBool("Run", false);
        }
    }

    /// <summary>
    /// ���S����
    /// </summary>
    void Dead()
    {
        _anim.SetBool("Dead", true);
        GameManager.Instance.GameOver();
    }

    IEnumerator HealHp()
    {
        while(true)
        {
            _playerHp += SkillManager._healthRecoveryLevel;
            yield return new WaitForSeconds(3);
        }
    }
}
