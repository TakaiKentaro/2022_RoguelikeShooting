using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// クラス説明
/// </summary>
public class InGameManager : MonoBehaviour
{
    [Header("AudioSource")]
    [SerializeField,Tooltip("Audio")] AudioSource _audioSource;
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
        _audioSource.Play();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("ResultScene");
    }
}
