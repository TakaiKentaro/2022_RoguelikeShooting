using UnityEngine;
using System.Collections.Generic;
using System.Collections;

/// <summary>
/// エネミーを自動生成させる
/// </summary>
public class EnemySpowner : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField, Tooltip("生成するエネミー１")] Enemy _enemy1;
    [SerializeField, Tooltip("生成するエネミー2")] Enemy _enemy2;

    [Tooltip("経過時間")] float _timer;
    public float Timer => _timer;

    ObjectPool<Enemy> _enemyPool;
    void Start()
    {
        _enemyPool = new ObjectPool<Enemy>(_enemy1, this.gameObject.transform);
        _enemyPool = new ObjectPool<Enemy>(_enemy2, this.gameObject.transform);

        StartCoroutine(SpownEnemy());
    }

    void Update()
    {
        
    }

    /// <summary>
    /// 敵をスポーンさせる
    /// </summary>
    int spownTime = 3;
    private void SpownEnemy(int time)
    {
        if(time % spownTime == 0)
        {
            Debug.Log(time);
            spownTime += 3;
        }
    }

    IEnumerator SpownEnemy()
    {
        var enemy = _enemyPool.Use();
        enemy.transform.parent = this.transform;
        yield return new WaitForSeconds(3);
        SpownEnemy();
    }
}
