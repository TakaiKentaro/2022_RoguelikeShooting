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

    [Header("Bullet")]
    [SerializeField, Tooltip("BulletObject")] GameObject _bullet;
    [SerializeField, Tooltip("BulletObjectPool")] ObjectPool _objectPool;

    
    [Tooltip("プレイヤーのRigidBody2D")] Rigidbody2D _rb2d;
    [Tooltip("プレイヤーの位置")] Transform _playerPos;



    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        
        if(Input.GetButtonDown("Jump"))
        {
            BulletFire();
        }
    }

    void PlayerMove()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;
        _rb2d.velocity = direction * _moveSpeed;
    }

    /// <summary>
    /// 弾を打つ関数
    /// </summary>
    void BulletFire()
    {
        Debug.Log("売った");
        
        GameObject go = _objectPool.GetPoolObject();
        if (go == null) return;

        foreach (GameObject i in _muzzle)
        {
            go.transform.position = i.transform.position;
            go.transform.rotation = i.transform.rotation;
            go.SetActive(true);
        }
    }
}
