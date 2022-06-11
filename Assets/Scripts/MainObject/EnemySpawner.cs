using UnityEngine;
using System.Collections.Generic;
using System.Collections;

/// <summary>
/// �G�l�~�[����������������
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField, Tooltip("��������G�l�~�[�P")] Enemy _enemy1;
    [SerializeField, Tooltip("��������G�l�~�[2")] Enemy _enemy2;

    [Tooltip("�o�ߎ���")]public float _timer = 2;
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
    /// �G���X�|�[��������
    /// </summary>
    IEnumerator SpownEnemy()
    {    
        while(true)
        {
            var enemy1 = _enemyPool1.Use();
            enemy1.transform.parent = this.transform;
            var enemy2 = _enemyPool2.Use();
            enemy2.transform.parent = this.transform;

            Debug.Log($"EnemySpown");

            yield return new WaitForSeconds(Timer);
        }  
    }
}
