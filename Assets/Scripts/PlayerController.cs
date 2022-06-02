using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�N���X
/// </summary>
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("�X�e�[�^�X")]
    [SerializeField, Tooltip("�̗�")] byte _playerHp = 100;
    [SerializeField, Tooltip("�ړ����x")] byte _playerSpeed = 3;
    [SerializeField, Tooltip("�U����")] byte _playerPower = 1;

    [Header("Muzzle")]
    [SerializeField, Tooltip("MuzzleObject")] GameObject[] _muzzle;

    
    [Tooltip("�v���C���[��RigidBody2D")] Rigidbody _rb;
    [Tooltip("�v���C���[�̈ʒu")] Transform _playerPos;

    [Tooltip("�v���C���[�̃A�j���[�^�[")] Animator _anim;


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
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

        if(h != 0 || v != 0)
        {
            _anim.SetBool("Run", true);
        }
        else
        {
            _anim.SetBool("Run", false);
        }
    }
}
