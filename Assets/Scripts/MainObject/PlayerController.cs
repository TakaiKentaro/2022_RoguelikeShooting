using UnityEngine;
using System.Collections;

/// <summary>
/// プレイヤークラス
/// </summary>
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("ステータス")]
    [Tooltip("体力上限")] public static float _playerHpMaxValue = 100;
    [Tooltip("現在の体力")] public static float _playerHp = 100;
    [SerializeField, Tooltip("移動速度")]public static int _playerSpeed = 3;

    [Tooltip("プレイヤーのRigidBody2D")] Rigidbody _rb;
    [Tooltip("プレイヤーの位置")] Transform _playerPos;

    [Tooltip("プレイヤーのアニメーター")] Animator _anim;

    void Start()
    {
        GameManager.Instance.SetPlayer(this);
        _playerHpMaxValue = 100;
        _playerHp = 100;
        _playerSpeed = 3;
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        StartCoroutine(HealHp());
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerHp <= 0)
        {
            Dead();
        }
        else
        {
            PlayerMove();
        }
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

        if (h != 0 || v != 0)
        {
            _anim.SetBool("Run", true);
        }
        else
        {
            _anim.SetBool("Run", false);
        }
    }

    /// <summary>
    /// 死亡判定
    /// </summary>
    void Dead()
    {
        _anim.SetBool("Dead", true);
        GameManager.Instance.GameOver();
    }

    IEnumerator HealHp()
    {
        while(true)
        {
            _playerHp += SkillManager._healthRecoveryLevel;
            yield return new WaitForSeconds(3);
        }
    }
}
