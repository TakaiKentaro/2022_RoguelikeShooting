using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// レベルアップクラス
/// </summary>
public class LevelUpManager : MonoBehaviour
{
    [Header("LevelUpCanvas")]
    [SerializeField, Tooltip("レベルアップ用Canvas")] GameObject _canvas;

    [SerializeField, Tooltip("スキルボタン1")] RectTransform[] _button;

    [Tooltip("Bool判定")] bool[] _check;

    [Tooltip("出力する個数の上限")] int count = 0;

    private void Start()
    {
        GameManager.Instance.SetLevelManager(this);
        foreach (var i in _button) i.gameObject.SetActive(false);
        _check = new bool[_button.Length];
        _canvas.gameObject.SetActive(false);
    }

    /// <summary>
    /// レベルアップした時の処理
    /// </summary>
    public void LevelUp()
    {
        _canvas.gameObject.SetActive(true);

        while (count < 3)
        {
            int index = Random.Range(0, _button.Length);
            Debug.Log(index);
            Debug.Log($"カウント{count}");
            if (_check[index] == true)
            {
                continue;
            }
            if (count == 0)
            {
                _button[index].localPosition = new Vector2(-450, 0);
                _check[index] = true;
                _button[index].gameObject.SetActive(true);
            }
            if (count == 1)
            {
                _button[index].localPosition = new Vector2(0, 0);
                _check[index] = true;
                _button[index].gameObject.SetActive(true);
            }
            if (count == 2)
            {
                _button[index].localPosition = new Vector2(450, 0);
                _check[index] = true;
                _button[index].gameObject.SetActive(true);
            }
            count++;
        }
        count = 0;
    }

    /// <summary>
    /// Canvasを非アクティブ化
    /// </summary>
    public void OnClickClose()
    {
        foreach (var i in _button) i.gameObject.SetActive(false);
        for (int i = 0; i < _check.Length; i++) _check[i] = false;
        _canvas.gameObject.SetActive(false);
    }
}
