using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BulletController : MonoBehaviour
{
    [Header("Status")]
    [SerializeField, Tooltip("É_ÉÅÅ[ÉW")] int _bulletDamage;
    [SerializeField, Tooltip("íeÇÃë¨Ç≥")] int _bulletSpeed;

    [Tooltip("íeÇÃRigidBody2D")] Rigidbody2D _rb2d;
    [Tooltip("íeÇÃà íu")] Transform _playerPos;
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
