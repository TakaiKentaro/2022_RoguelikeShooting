using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// レベルアップクラス
/// </summary>
public class LevelUpManager : MonoBehaviour
{
    [Header("LevelUpCanvas")]
    [SerializeField, Tooltip("レベルアップ用Canvas")] GameObject _canvas;

    [SerializeField, Tooltip("スキルボタン1")] Button _button1;
    [SerializeField, Tooltip("スキルボタン2")] Button _button2;
    [SerializeField, Tooltip("スキルボタン3")] Button _button3;

    [SerializeField, Tooltip("スキルテキスト1")] Text _text1;
    [SerializeField, Tooltip("スキルテキスト2")] Text _text2;
    [SerializeField, Tooltip("スキルテキスト3")] Text _text3;

}
