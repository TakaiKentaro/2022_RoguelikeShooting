using UnityEngine;

/// <summary>
/// エネミーを自動生成させる
/// </summary>
public class EnemySpowner : MonoBehaviour
{
    [SerializeField,Tooltip("生成するオブジェクト")] Enemy _enemy;
    ObjectPool<Enemy> _enemyPool;
    void Start()
    {
        _enemyPool = new ObjectPool<Enemy>(_enemy, this.gameObject.transform);
    }

    void Update()
    {
        var enemy = _enemyPool.Use();
        enemy.transform.parent = this.transform;
    }
}
