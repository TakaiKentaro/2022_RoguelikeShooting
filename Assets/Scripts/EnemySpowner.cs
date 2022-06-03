using UnityEngine;

/// <summary>
/// エネミーを自動生成させる
/// </summary>
public class EnemySpowner : MonoBehaviour
{
    [SerializeField,Tooltip("生成するエネミー１")] Enemy _enemy1;
    [SerializeField, Tooltip("生成するエネミー2")] Enemy _enemy2;
    ObjectPool<Enemy> _enemyPool;
    void Start()
    {
        _enemyPool = new ObjectPool<Enemy>(_enemy1, this.gameObject.transform);
        _enemyPool = new ObjectPool<Enemy>(_enemy2, this.gameObject.transform);
    }

    void Update()
    {
        var enemy = _enemyPool.Use();
        enemy.transform.parent = this.transform;
    }
}
