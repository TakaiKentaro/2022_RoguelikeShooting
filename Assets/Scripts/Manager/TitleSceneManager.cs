using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// TitleSceneManagerクラス
/// </summary>
public class TitleSceneManager : MonoBehaviour
{
    [Header("ステータス")]
    [SerializeField, Tooltip("HightScoreText")] Text _hightScoreText;
    [Tooltip("Score保存")]static int _hightScore;

    void Start()
    {
        if (_hightScore <= GameManager._killCount) _hightScore = GameManager._killCount;
        _hightScoreText.text = $"ハイスコア：{_hightScore}";
    }

    /// <summary>
    /// InGameSceneに行く
    /// </summary>
    public void OnClickInGame()
    {
        SceneManager.LoadScene("InGameScene");
    }

    /// <summary>
    /// Gameを終了
    /// </summary>
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
    }
}
