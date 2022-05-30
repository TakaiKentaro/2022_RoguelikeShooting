using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemyの基底クラス
/// </summary>
public class EnemyBase : MonoBehaviour
{
    [Header("ステータス")]
    [SerializeField, Tooltip("エネミーの体力")] byte _enemyHp;
    [SerializeField, Tooltip("エネミーの攻撃力")] byte _enemyPower;
    [SerializeField,Tooltip("エネミーのスピード")] byte _enemySpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
