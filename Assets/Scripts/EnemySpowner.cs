using UnityEngine;

/// <summary>
/// �G�l�~�[����������������
/// </summary>
public class EnemySpowner : MonoBehaviour
{
    [SerializeField,Tooltip("��������G�l�~�[�P")] Enemy _enemy1;
    [SerializeField, Tooltip("��������G�l�~�[2")] Enemy _enemy2;
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
