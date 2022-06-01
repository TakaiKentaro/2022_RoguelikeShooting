using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameManagerクラス
/// </summary>
public class GameManager : MonoBehaviour
{
    static private GameManager _instance = new GameManager();
    static public GameManager Instance => _instance;

    private GameManager() { }


    [Tooltip("プレイヤー")] PlayerController _player;
    [Tooltip("倒した敵の数")] int _killEnemyCount;
    [Tooltip("時間")] float _gameTime;
    [Tooltip("プレイヤーのレベル")] int _level = 1;
    [Tooltip("レベルアップに必要な経験値")] int _exp = 10;

    private void Update()
    {
        
    }

    /// <summary>
    /// 時間経過
    /// </summary>
    void CountTime()
    {
        _gameTime = Time.time;
        Debug.Log($"{_gameTime}");
    }
}
