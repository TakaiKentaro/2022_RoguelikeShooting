using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI���Ǘ�����N���X
/// </summary>
public class UIManager : MonoBehaviour
{
    [Header("�X�e�[�^�X")]
    [SerializeField, Tooltip("Time�e�L�X�g")] Text _timeText;
    [SerializeField, Tooltip("�o���l�X���C�_�[")] Slider _expSlider;
    [SerializeField, Tooltip("Level�e�L�X�g")] Text _levelText;
    [SerializeField, Tooltip("Kill�e�L�X�g")] Text _killText;

    [Tooltip("���ƕb")] int min, sec;
    private void Update()
    {
        Time(GameManager.Instance._gameTimer);
        Exp(GameManager.Instance._expMaxValue, GameManager.Instance._saveExp);
        Leve(GameManager.Instance._level);
        Kill(GameManager.Instance._killCount);
    }

    /// <summary>
    /// ���Ԍv�Z
    /// </summary>
    /// <param name="time"></param>
    void Time(float time)
    {
        min = (int)time / 60;
        sec = (int)time % 60;

        _timeText.text = $"{min}��{sec}�b";
    }

    /// <summary>
    /// �o���l
    /// </summary>
    /// <param name="maxExp"></param>
    /// <param name="saveExp"></param>
    void Exp(int maxExp,int saveExp)
    {
        _expSlider.maxValue = maxExp;
        _expSlider.value = saveExp;
    }

    /// <summary>
    /// ���x��
    /// </summary>
    /// <param name="level"></param>
    void Leve(int level)
    {
        _levelText.text = $"Level {level}";
    }

    /// <summary>
    /// �L���J�E���g
    /// </summary>
    /// <param name="count"></param>
    void Kill(int count)
    {
        _killText.text = $"Kill {count}";
    }
}