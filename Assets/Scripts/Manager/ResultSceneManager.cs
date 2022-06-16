using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// ResultSceneクラス
/// </summary>
public class ResultSceneManager : MonoBehaviour
{
    [Header("リザルトステータス")]
    [SerializeField, Tooltip("ResultText")] Text _resultText;
    void Start()
    {
        _resultText.text = $"スコア：{GameManager._killCount}";
    }

    /// <summary>
    /// タイトルに戻る
    /// </summary>
    public void OnClickTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }

    /// <summary>
    /// InGameに戻る
    /// </summary>
    public void OnClickInGame()
    {
        SceneManager.LoadScene("InGameScene");
    }
}
