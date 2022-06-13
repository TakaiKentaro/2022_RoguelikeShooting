using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// レベルアップクラス
/// </summary>
public class LevelUpManager : MonoBehaviour
{
    [Header("LevelUpCanvas")]
    [SerializeField, Tooltip("レベルアップ用Canvas")] GameObject _canvas;

    [SerializeField, Tooltip("スキルボタン1")] Image _button1;
    [SerializeField, Tooltip("スキルボタン2")] Image _button2;
    [SerializeField, Tooltip("スキルボタン3")] Image _button3;

    [SerializeField, Tooltip("スキルテキスト1")] Text _text1;
    [SerializeField, Tooltip("スキルテキスト2")] Text _text2;
    [SerializeField, Tooltip("スキルテキスト3")] Text _text3;

    private void Start()
    {
        _button1 = GetComponent<Image>();
        _button2 = GetComponent<Image>();
        _button3 = GetComponent<Image>();
        _text1 = GetComponent<Text>();
        _text2 = GetComponent<Text>();
        _text3 = GetComponent<Text>();

        _canvas.gameObject.SetActive(false);
    }

    /// <summary>
    /// レベルアップした時の処理
    /// </summary>
    public void LevelUp()
    {

    }

}
