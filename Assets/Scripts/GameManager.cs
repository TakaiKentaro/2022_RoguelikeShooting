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
    public void SetPlayer(PlayerController p) { _player = p; }
    [Tooltip("倒した敵の数")] int _killCount;
    [Tooltip("プレイヤーのレベル")] int _level = 1;
    [Tooltip("レベルアップに必要な経験値")] int _exp = 10;
    /// <summary>
    /// クリスタルを取得したときの処理
    /// </summary>
    public void Exp()
    {

    }

    /// <summary>
    /// Enemyを倒したとき呼ぶ関数
    /// </summary>
    public void KillCount()
    {
        _killCount++;
    }

    static public PlayerController Player => _instance._player;
}
