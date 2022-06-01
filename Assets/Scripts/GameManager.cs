using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameManager�N���X
/// </summary>
public class GameManager : MonoBehaviour
{
    static private GameManager _instance = new GameManager();
    static public GameManager Instance => _instance;

    private GameManager() { }


    [Tooltip("�v���C���[")] PlayerController _player;
    [Tooltip("�|�����G�̐�")] int _killEnemyCount;
    [Tooltip("����")] float _gameTime;
    [Tooltip("�v���C���[�̃��x��")] int _level = 1;
    [Tooltip("���x���A�b�v�ɕK�v�Ȍo���l")] int _exp = 10;

    private void Update()
    {
        
    }

    /// <summary>
    /// ���Ԍo��
    /// </summary>
    void CountTime()
    {
        _gameTime = Time.time;
        Debug.Log($"{_gameTime}");
    }
}
