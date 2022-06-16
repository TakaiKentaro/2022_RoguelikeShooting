using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// クラス説明
/// </summary>
public class InGameManager : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.SetInGameManager(this);
    }

    /// <summary>
    /// Resultシーンに行く
    /// </summary>
    public void ResultScene()
    {
        StartCoroutine(ResultTime());
    }

    IEnumerator ResultTime()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("ResultScene");
    }
}
