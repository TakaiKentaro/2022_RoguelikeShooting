using UnityEngine;

/// <summary>
/// SkillManagerクラス
/// </summary>
public class SkillManager : MonoBehaviour
{
    [Tooltip("SwordUpレベル")] static public int _swordUpLevel;
    [Tooltip("SwordPlusレベル")] static public int _swordPlusLevel;
    [Tooltip("SwordIntervalレベル")] static public float _swordIntervalLevel;
    [Tooltip("SpeedUpレベル")] static public float _speedUpLevel;
    [Tooltip("HealthUpレベル")] static public int _healthUpLevel;
    [Tooltip("HealthRecoveryレベル")] static public int _healthRecoveryLevel;

    private void Awake()
    {
        _swordUpLevel = 1;
        _swordPlusLevel = 1;
        _swordIntervalLevel = 0.1f;
        _speedUpLevel = 0.5f;
        _healthUpLevel = 10;
        _healthRecoveryLevel = 1;
    }

    /// <summary>
    /// SwordUpスキルを取得
    /// </summary>
    public void SwordUp()
    {
        _swordUpLevel++;
        WeaponSword._attackDmg += _swordUpLevel;
    }

    /// <summary>
    /// SwordPlusスキルを取得
    /// </summary>
    public void SwordPlus()
    {
        _swordPlusLevel++;
    }

    /// <summary>
    /// SwordIntervalスキルを取得
    /// </summary>
    public void SwordInterval()
    {
        WeaponSpawner._timer -= _swordIntervalLevel;
    }

    /// <summary>
    /// SpeedUpスキルを取得
    /// </summary>
    public void SpeedUp()
    {
        PlayerController._playerSpeed += _speedUpLevel;
    }

    /// <summary>
    /// HealthUpスキルを取得
    /// </summary>
    public void HealthUp()
    {
        PlayerController._playerHpMaxValue += _healthUpLevel;
    }

    /// <summary>
    /// HealthRecoveryスキルを取得
    /// </summary>
    public void HealthRecovery()
    {
        _healthRecoveryLevel++;
    }
}
