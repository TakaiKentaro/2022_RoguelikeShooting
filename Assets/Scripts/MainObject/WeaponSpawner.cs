using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Weponを生成する
/// </summary>
public class WeaponSpawner : MonoBehaviour
{
    [Header("Wepon")]
    [SerializeField, Tooltip("生成するWepon1")] WeaponSword _weapon1;
    [SerializeField, Tooltip("生成するWepon1")] WeaponSword _weapon2;
    [SerializeField, Tooltip("生成するWepon1")] WeaponSword _weapon3;
    [SerializeField, Tooltip("生成するWepon1")] WeaponSword _weapon4;
    [SerializeField, Tooltip("生成するWepon1")] WeaponSword _weapon5;
    [SerializeField, Tooltip("生成するWepon1")] WeaponSword _weapon6;
    [SerializeField, Tooltip("生成するWepon1")] WeaponSword _weapon7;
    [SerializeField, Tooltip("生成するWepon1")] WeaponSword _weapon8;

    [Header("生成する場所")]

    [Tooltip("経過時間")]static public float _timer;
    public float Timer => _timer;

    ObjectPool<WeaponSword> _weaponPool1, _weaponPool2, _weaponPool3, _weaponPool4, _weaponPool5, _weaponPool6, _weaponPool7, _weaponPool8;
    void Start()
    {
        _timer = _weapon1._timer;

        _weaponPool1 = new ObjectPool<WeaponSword>(_weapon1, this.gameObject.transform);
        _timer = _weapon1._timer;
        _weaponPool2 = new ObjectPool<WeaponSword>(_weapon2, this.gameObject.transform);
        _timer = _weapon1._timer;
        _weaponPool3 = new ObjectPool<WeaponSword>(_weapon3, this.gameObject.transform);
        _timer = _weapon1._timer;
        _weaponPool4 = new ObjectPool<WeaponSword>(_weapon4, this.gameObject.transform);
        _timer = _weapon1._timer;
        _weaponPool5 = new ObjectPool<WeaponSword>(_weapon5, this.gameObject.transform);
        _timer = _weapon1._timer;
        _weaponPool6 = new ObjectPool<WeaponSword>(_weapon6, this.gameObject.transform);
        _timer = _weapon1._timer;
        _weaponPool7 = new ObjectPool<WeaponSword>(_weapon7, this.gameObject.transform);
        _timer = _weapon1._timer;
        _weaponPool8 = new ObjectPool<WeaponSword>(_weapon8, this.gameObject.transform);

        StartCoroutine(SpownWepon());
    }

    /// <summary>
    /// 武器をスポーンさせる
    /// </summary>
    IEnumerator SpownWepon()
    {
        while (true)
        {
            int level = SkillManager._swordPlusLevel;

            if (level > 0)
            {
                var weapon1 = _weaponPool1.Use();
                weapon1.transform.parent = this.transform;
                if (level > 8)
                {
                    StartCoroutine(SpownWepon2(weapon1));
                }
            }
            if (level > 1)
            {
                var weapon2 = _weaponPool2.Use();
                weapon2.transform.parent = this.transform;
                if (level > 9)
                {
                    StartCoroutine(SpownWepon2(weapon2));
                }
            }
            if (level > 2)
            {
                var weapon3 = _weaponPool3.Use();
                weapon3.transform.parent = this.transform;
                if (level > 10)
                {
                    StartCoroutine(SpownWepon2(weapon3));
                }
            }
            if (level > 3)
            {
                var weapon4 = _weaponPool4.Use();
                weapon4.transform.parent = this.transform;
                if (level > 11)
                {
                    StartCoroutine(SpownWepon2(weapon4));
                }
            }
            if (level > 4)
            {
                var weapon5 = _weaponPool5.Use();
                weapon5.transform.parent = this.transform;
                if (level > 12)
                {
                    StartCoroutine(SpownWepon2(weapon5));
                }
            }
            if (level > 5)
            {
                var weapon6 = _weaponPool6.Use();
                weapon6.transform.parent = this.transform;
                if (level > 13)
                {
                    StartCoroutine(SpownWepon2(weapon6));
                }
            }
            if (level > 6)
            {
                var weapon7 = _weaponPool7.Use();
                weapon7.transform.parent = this.transform;
                if (level > 14)
                {
                    StartCoroutine(SpownWepon2(weapon7));
                }
            }
            if (level > 7)
            {
                var weapon8 = _weaponPool8.Use();
                weapon8.transform.parent = this.transform;
                if (level > 15)
                {
                    StartCoroutine(SpownWepon2(weapon8));
                }
            }

            yield return new WaitForSeconds(Timer);
        }
    }

    /// <summary>
    /// Swordの数が8を超えたら
    /// </summary>
    /// <param name="wepon"></param>
    /// <returns></returns>
    IEnumerator SpownWepon2(WeaponSword wepon)
    {
        wepon.transform.parent = this.transform;
        yield return new WaitForSeconds(1);    
    }
}
