using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BulletController : MonoBehaviour
{
    [Header("Status")]
    [SerializeField, Tooltip("�_���[�W")] int _bulletDamage;
    [SerializeField, Tooltip("�e�̑���")] int _bulletSpeed;

    [Tooltip("�e��RigidBody2D")] Rigidbody2D _rb2d;
    [Tooltip("�e�̈ʒu")] Transform _playerPos;


    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb2d.AddForce(transform.up * _bulletSpeed, ForceMode2D.Impulse);
    }

    void OnBecameInvisible() //��ʊO�ɏo���������
    {
        this.gameObject.SetActive(false);
    }
}
