using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour
{
    [Header("Status")]
    [SerializeField, Tooltip("�_���[�W")] int _bulletDamage;
    [SerializeField, Tooltip("�e�̑���")] int _bulletSpeed;

    [Tooltip("�e��RigidBody2D")] Rigidbody _rb;
    [Tooltip("�e�̈ʒu")] Transform _playerPos;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.AddForce(transform.up * _bulletSpeed, ForceMode.Impulse);
    }

    void OnBecameInvisible() //��ʊO�ɏo���������
    {
        this.gameObject.SetActive(false);
    }
}
