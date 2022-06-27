using UnityEngine;

/// <summary>
/// GameManagerクラス
/// </summary>
public class GameManager : MonoBehaviour
{
    static private GameManager _instance = null;
    static public GameManager Instance => _instance;
    //private GameManager() { }

    static public PlayerController Player => _instance._player;
    static public LevelUpManager LevelUpManager => _instance._levelUpManager;
    static public InGameManager InGameManager => _instance._inGameManager;

    [Tooltip("プレイヤー")] PlayerController _player;
    public void SetPlayer(PlayerController p) { _player = p; }

    [Tooltip("レベルアップマネージャー")] LevelUpManager _levelUpManager;
    public void SetLevelManager(LevelUpManager lev) { _levelUpManager = lev; }

    [Tooltip("InGameマネージャー")] InGameManager _inGameManager;
    public void SetInGameManager(InGameManager ingame) { _inGameManager = ingame; }

    [Tooltip("倒した敵の数")] public static int _killCount;
    [Tooltip("タイマー")] public float _gameTimer;
    [Tooltip("プレイヤーのレベル")] public int _level = 1;
    [Tooltip("経験値の合計を保存")] public int _saveExp = 0;
    [Tooltip("レベルアップに必要な経験値")] public int _expMaxValue = 5;


    private void Awake()
    {
        if (!_instance)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        _killCount = 0;
    }

    private void OnDestroy()
    {
        if (_instance == this)
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
    public void GameOver()
    {
        _inGameManager.ResultScene();
    }

    /// <summary>
    /// クリスタルを取得したときの処理
    /// </summary>
    public void Exp(int exp)
    {
        Debug.Log("経験値アップ");
        _saveExp += exp;
        if (_saveExp >= _expMaxValue)
        {
            Debug.Log("レベルアップ");
            _level++;
            _saveExp = 0;
            _expMaxValue += 5;
            _levelUpManager.LevelUp();
            TimeScale();   
        }
    }

    /// <summary>
    /// ゲーム時間制御
    /// </summary>
    public void TimeScale()
    {
        if (Time.timeScale <= 0.99)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    /// <summary>
    /// Enemyを倒したとき呼ぶ関数
    /// </summary>
    public void KillCount()
    {
        _killCount++;
    }
}
