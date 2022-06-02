using UnityEngine;

/// <summary>
/// �G�l�~�[����������������
/// </summary>
public class EnemySpowner : MonoBehaviour
{
    [SerializeField,Tooltip("��������I�u�W�F�N�g")] Enemy _enemy;
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
