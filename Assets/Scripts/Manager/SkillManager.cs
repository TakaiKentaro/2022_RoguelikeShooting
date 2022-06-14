using UnityEngine;

/// <summary>
/// SkillManagerクラス
/// </summary>
public class SkillManager : MonoBehaviour
{
    [Tooltip("SwordUpレベル")] static int _swordUpLevel = 1;
    [Tooltip("SwordPlusレベル")] static int _swordPlusLevel = 1;
    [Tooltip("SwordIntervalレベル")] static int _swordIntervalLevel = 1;
    [Tooltip("SpeedUpレベル")] static int _speedUpLevel = 1;
    [Tooltip("HealthUpレベル")] static int _healthUpLevel = 1;
    [Tooltip("HealthRecoveryレベル")] static int _healthRecoveryLevel = 1;

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
