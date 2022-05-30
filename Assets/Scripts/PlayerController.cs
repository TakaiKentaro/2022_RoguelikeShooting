using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤークラス
/// </summary>
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("ステータス")]
    [SerializeField, Tooltip("体力")] byte _playerHp = 100;
    [SerializeField, Tooltip("移動速度")] byte _playerSpeed = 3;
    [SerializeField, Tooltip("攻撃力")] byte _playerPower = 1;

    [Header("Muzzle")]
    [SerializeField, Tooltip("MuzzleObject")] GameObject[] _muzzle;

    [Header("Bullet")]
    [SerializeField, Tooltip("BulletObject")] GameObject _bullet;
    [SerializeField, Tooltip("BulletObjectPool")] ObjectPool _objectPool;

    
    [Tooltip("プレイヤーのRigidBody2D")] Rigidbody _rb;
    [Tooltip("プレイヤーの位置")] Transform _playerPos;

    [Tooltip("プレイヤーのアニメーター")] Animator _anim;


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
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
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(h, 0, v);

        dir = Camera.main.transform.TransformDirection(dir);
        dir.y = 0;

        transform.rotation = Quaternion.LookRotation(dir);
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
