using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Status")]
    [SerializeField, Tooltip("体力")] int _playerHp;
    [SerializeField, Tooltip("移動速度")] float _moveSpeed;

    [Header("Muzzle")]
    [SerializeField, Tooltip("MuzzleObject")] GameObject[] _muzzle;

    [Tooltip("プレイヤーのRigidBody2D")] Rigidbody2D _rb2d;
    [Tooltip("プレイヤーの位置")] Transform _playerPos;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
