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
    [Tooltip("体力")]public float _playerHp = 100;
    [SerializeField, Tooltip("移動速度")] byte _playerSpeed = 3;
    [Tooltip("攻撃力")]public byte _playerPower = 1;
 
    [Tooltip("プレイヤーのRigidBody2D")] Rigidbody _rb;
    [Tooltip("プレイヤーの位置")] Transform _playerPos;

    [Tooltip("プレイヤーのアニメーター")] Animator _anim;

    private void Awake()
    {
        GameManager.Instance.SetPlayer(this);
    }

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
    /// プレイヤーの移動
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

    /// <summary>
    /// 敵に当たった時の処理
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
