using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameManagerクラス
/// </summary>
public class GameManager : MonoBehaviour
{
    static private GameManager _instance = null;
    static public GameManager Instance => _instance;
    //private GameManager() { }


    [Tooltip("プレイヤー")] PlayerController _player;
    public void SetPlayer(PlayerController p) { _player = p; }

    [Tooltip("倒した敵の数")]public int _killCount;
    [Tooltip("タイマー")]public float _gameTimer;
    [Tooltip("プレイヤーのレベル")]public int _level = 1;
    [Tooltip("経験値の合計を保存")]public int _saveExp = 0;
    [Tooltip("レベルアップに必要な経験値")]public int _expMaxValue = 10;

    private void Awake()
    {
        if(!_instance)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }

    private void OnDestroy()
    {
        if(_instance == this)
        {
            _instance = null;
        }
    }


    private void Update()
    {
        _gameTimer += Time.deltaTime;    
    }

    /// <summary>
    /// プレイヤーの体力が0になった時に呼ぶ
    /// </summary>
    /// <param name="check"></param>
    void GameOver(bool check)
    {

    }

    /// <summary>
    /// クリスタルを取得したときの処理
    /// </summary>
    public void Exp(int exp)
    {
        Debug.Log("経験値アップ");
        _saveExp += exp;
        if(_saveExp >= _expMaxValue)
        {
            _level++;
            _saveExp = 0;
            _expMaxValue += 10;
        }
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
