using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Wepon : MonoBehaviour, IPool
{

    [Header("ステータス")]
    [Tooltip("攻撃力")] public byte _attackDmg = 1;
    [Tooltip("移動速度")] public float _weponSpeed = 1;
    [Tooltip("個数")] public byte _weponNum = 1;
    [SerializeField, Tooltip("インターバル")] float _timer;

    [Tooltip("発射の位置")] Vector3 _shootVec;
    [Tooltip("TargetEnemy")] Enemy _target;

    [Tooltip("消える判定")] bool _check;

    public bool Waiting { get; set; }

    /// <summary>
    /// 生成時の初期化. Start関数
    /// </summary>
    /// <param name="parent">親Object</param>
    public void SetUp(Transform parent)
    { 
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Useした際の初期化. Start関数
    /// </summary>
    public void IsUseSetUp()
    {
        if (_target == null) return;

        _shootVec = _target.transform.position - GameManager.Player.transform.position;
        _shootVec.Normalize();

        _check = true;
        _timer = 0;
        _target = GetComponent<Enemy>();
        gameObject.SetActive(true);
    }

    /// <summary>
    /// 使用中の処理. Update関数 trueが返る限り周り続ける
    /// </summary>
    /// <returns></returns>
    public bool Execute()
    {
        transform.position += _shootVec * _weponSpeed * Time.deltaTime;

        return true;
    }

    /// <summary>
    /// Executeがおわった際の処理, Destroy関数
    /// </summary>
    public void Delete()
    {

    }

}
