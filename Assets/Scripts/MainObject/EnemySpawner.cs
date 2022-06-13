using UnityEngine;
using System.Collections.Generic;
using System.Collections;

/// <summary>
/// エネミーを自動生成させる
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField, Tooltip("生成するエネミー１")] Enemy _enemy1;
    [SerializeField, Tooltip("生成するエネミー2")] Enemy _enemy2;

    [Header("SpownPoint")]
    [SerializeField, Tooltip("エネミーのスポーンする場所")] Transform[] _spownPoint;

    [Tooltip("経過時間")] public float _timer = 2;
    public float Timer => _timer;

    ObjectPool<Enemy> _enemyPool1;
    ObjectPool<Enemy> _enemyPool2;
    void Start()
    {
        _enemyPool1 = new ObjectPool<Enemy>(_enemy1, this.gameObject.transform);
        _enemyPool2 = new ObjectPool<Enemy>(_enemy2, this.gameObject.transform);

        StartCoroutine(SpownEnemy());
    }

    /// <summary>
    /// 敵をスポーンさせる
    /// </summary>
    IEnumerator SpownEnemy()
    {
        while (true)
        {
            int _rnd1 = Random.Range(0, _spownPoint.Length - 1);
            var enemy1 = _enemyPool1.Use();
            enemy1.transform.parent = _spownPoint[_rnd1];

            int _rnd2 = Random.Range(0, _spownPoint.Length - 1);
            var enemy2 = _enemyPool2.Use();
            enemy2.transform.parent = _spownPoint[_rnd2];

            Debug.Log($"EnemySpown");

            yield return new WaitForSeconds(Timer);
        }
    }
}
