using UnityEngine;

/// <summary>
/// SkillManagerクラス
/// </summary>
public class SkillManager : MonoBehaviour
{
    [Tooltip("SwordUpレベル")] static int _swordUpLevel;
    [Tooltip("SwordPlusレベル")] static int _swordPlusLevel;
    [Tooltip("SwordIntervalレベル")] static int _swordIntervalLevel;
    [Tooltip("SpeedUpレベル")] static int _speedUpLevel;
    [Tooltip("HealthUpレベル")] static int _healthUpLevel;
    [Tooltip("HealthRecoveryレベル")] static int _healthRecoveryLevel;

    /// <summary>
    /// SwordUpスキルを取得
    /// </summary>
    public void SwordUp()
    {
        _swordUpLevel++;
    }

    /// <summary>
    /// SwordPlusスキルを取得
    /// </summary>
    public void SwordPlus()
    {
        if (_swordPlusLevel <= 8) _swordPlusLevel++;
    }

    /// <summary>
    /// SwordIntervalスキルを取得
    /// </summary>
    public void SwordInterval()
    {
        _swordIntervalLevel++;
    }

    /// <summary>
    /// SpeedUpスキルを取得
    /// </summary>
    public void SpeedUp()
    {
        _speedUpLevel++;
    }

    /// <summary>
    /// HealthUpスキルを取得
    /// </summary>
    public void HealthUp()
    {
        _healthUpLevel++;
    }

    /// <summary>
    /// HealthRecoveryスキルを取得
    /// </summary>
    public void HealthRecovery()
    {
        _healthRecoveryLevel++;
    }
}
