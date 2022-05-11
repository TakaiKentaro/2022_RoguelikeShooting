using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BulletController : MonoBehaviour
{
    [Header("Status")]
    [SerializeField, Tooltip("ダメージ")] int _bulletDamage;
    [SerializeField, Tooltip("弾の速さ")] int _bulletSpeed;

    [Tooltip("弾のRigidBody2D")] Rigidbody2D _rb2d;
    [Tooltip("弾の位置")] Transform _playerPos;
    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb2d.AddForce(new Vector2(0, _bulletSpeed), ForceMode2D.Impulse);
    }
}
