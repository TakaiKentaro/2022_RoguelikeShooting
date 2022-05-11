using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Status")]
    [SerializeField, Tooltip("�̗�")] int _playerHp;
    [SerializeField, Tooltip("�ړ����x")] float _moveSpeed;

    [Header("Muzzle")]
    [SerializeField, Tooltip("MuzzleObject")] GameObject[] _muzzle;

    [Tooltip("�v���C���[��RigidBody2D")] Rigidbody2D _rb2d;
    [Tooltip("�v���C���[�̈ʒu")] Transform _playerPos;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
