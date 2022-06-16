using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UIを管理するクラス
/// </summary>
public class UIManager : MonoBehaviour
{
    [Header("InGame")]
    [SerializeField, Tooltip("Timeテキスト")] Text _timeText;
    [SerializeField, Tooltip("経験値スライダー")] Slider _expSlider;
    [SerializeField, Tooltip("Levelテキスト")] Text _levelText;
    [SerializeField, Tooltip("Killテキスト")] Text _killText;

    [Header("PlayerStatus")]
    [SerializeField, Tooltip("プレイヤーのHp")] Slider _playerHp;

    [Tooltip("分と秒")] int min, sec;

    private void Update()
    {
        Time(GameManager.Instance._gameTimer);
        Exp(GameManager.Instance._expMaxValue, GameManager.Instance._saveExp);
        Leve(GameManager.Instance._level);
        Kill(GameManager._killCount);
        PlayerHp();
    }

    /// <summary>
    /// 時間計算
    /// </summary>
    /// <param name="time"></param>
    void Time(float time)
    {
        min = (int)time / 60;
        sec = (int)time % 60;

        _timeText.text = $"{min}分{sec}秒";
    }

    /// <summary>
    /// 経験値
    /// </summary>
    /// <param name="maxExp"></param>
    /// <param name="saveExp"></param>
    void Exp(float maxExp, float saveExp)
    {
        _expSlider.maxValue = maxExp;
        _expSlider.value = saveExp;
    }

    /// <summary>
    /// レベル
    /// </summary>
    /// <param name="level"></param>
    void Leve(int level)
    {
        _levelText.text = $"レベル {level}";
    }

    /// <summary>
    /// キルカウント
    /// </summary>
    /// <param name="count"></param>
    void Kill(int count)
    {
        _killText.text = $"キル {count}";
    }

    void PlayerHp()
    {
        _playerHp.maxValue = PlayerController._playerHpMaxValue;
        _playerHp.value = PlayerController._playerHp;
    }
}
