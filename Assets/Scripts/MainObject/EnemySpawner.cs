using UnityEngine;
using System.Collections.Generic;
using System.Collections;

/// <summary>
/// エネミーを自動生成させる
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField, Tooltip("生成するスライム１")] Enemy _slime1;
    [SerializeField, Tooltip("生成するスライム2")] Enemy _slime2;

    [SerializeField, Tooltip("生成するスケルトン1")] Enemy _skeltone1;
    [SerializeField, Tooltip("生成するスケルトン2")] Enemy _skeltone2;
    [SerializeField, Tooltip("生成するスケルトン3")] Enemy _skeltone3;
    [SerializeField, Tooltip("生成するスケルトン4")] Enemy _skeltone4;

    [SerializeField, Tooltip("生成するスケルトンボス")] Enemy _skeltoneBoss;

    [Header("SpownPoint")]
    [SerializeField, Tooltip("エネミーのスポーンする場所")] Transform[] _spownPoint;

    [Tooltip("経過時間")] float _timer = 5;
    public float Timer => _timer;

    ObjectPool<Enemy> _slimePool1;
    ObjectPool<Enemy> _slimePool2;
    ObjectPool<Enemy> _skeltonPool1;
    ObjectPool<Enemy> _skeltonPool2;
    ObjectPool<Enemy> _skeltonPool3;
    ObjectPool<Enemy> _skeltonPool4;

    ObjectPool<Enemy> _skeltonBossPool;
    void Start()
    {
        _slimePool1 = new ObjectPool<Enemy>(_slime1, this.gameObject.transform);
        _slimePool2 = new ObjectPool<Enemy>(_slime2, this.gameObject.transform);

        _skeltonPool1 = new ObjectPool<Enemy>(_skeltone1, this.gameObject.transform);
        _skeltonPool2 = new ObjectPool<Enemy>(_skeltone2, this.gameObject.transform);
        _skeltonPool3 = new ObjectPool<Enemy>(_skeltone3, this.gameObject.transform);
        _skeltonPool4 = new ObjectPool<Enemy>(_skeltone4, this.gameObject.transform);

        _skeltonBossPool = new ObjectPool<Enemy>(_skeltoneBoss, this.gameObject.transform);

        StartCoroutine(SpawnEnemy());
        StartCoroutine(BossSpawn());
        StartCoroutine(CountUp());
    }

    /// <summary>
    /// 敵をスポーンさせる
    /// </summary>
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            var enemy1 = _slimePool1.Use();
            enemy1.transform.parent = this.transform;
            enemy1.transform.position = _spownPoint[Random.Range(0, _spownPoint.Length - 1)].position;

            if (GameManager.Instance._gameTimer >= 60)
            {
                var enemy2 = _slimePool2.Use();
                enemy2.transform.parent = this.transform;
                enemy2.transform.position = _spownPoint[Random.Range(0, _spownPoint.Length - 1)].position;
            }
            if (GameManager.Instance._gameTimer >= 120)
            {
                var enemy3 = _skeltonPool1.Use();
                enemy3.transform.parent = this.transform;
                enemy3.transform.position = _spownPoint[Random.Range(0, _spownPoint.Length - 1)].position;

                var enemy4 = _skeltonPool2.Use();
                enemy4.transform.parent = this.transform;
                enemy4.transform.position = _spownPoint[Random.Range(0, _spownPoint.Length - 1)].position;
            }
            if (GameManager.Instance._gameTimer >= 180)
            {
                var enemy5 = _skeltonPool3.Use();
                enemy5.transform.parent = this.transform;
                enemy5.transform.position = _spownPoint[Random.Range(0, _spownPoint.Length - 1)].position;

                var enemy6 = _skeltonPool4.Use();
                enemy6.transform.parent = this.transform;
                enemy6.transform.position = _spownPoint[Random.Range(0, _spownPoint.Length - 1)].position;
            }

            Debug.Log($"EnemySpown");

            yield return new WaitForSeconds(Timer);
        }
    }

    /// <summary>
    /// ボスの出現
    /// </summary>
    /// <returns></returns>
    IEnumerator BossSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(60);

            var enemyBoss = _skeltonBossPool.Use();
            enemyBoss.transform.parent = this.transform;
            enemyBoss.transform.position = _spownPoint[Random.Range(0, _spownPoint.Length - 1)].position;
        }
    }

    /// <summary>
    /// 敵の出現時間の短縮
    /// </summary>
    /// <returns></returns>
    IEnumerator CountUp()
    {
        while (true)
        {
            _timer -= 0.5f;
            yield return new WaitForSeconds(30);
        }
    }
}
