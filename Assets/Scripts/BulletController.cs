using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour
{
    [Header("Status")]
    [SerializeField, Tooltip("ダメージ")] int _bulletDamage;
    [SerializeField, Tooltip("弾の速さ")] int _bulletSpeed;

    [Tooltip("弾のRigidBody2D")] Rigidbody _rb;
    [Tooltip("弾の位置")] Transform _playerPos;


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

    void OnBecameInvisible() //画面外に出たら消える
    {
        this.gameObject.SetActive(false);
    }
}
