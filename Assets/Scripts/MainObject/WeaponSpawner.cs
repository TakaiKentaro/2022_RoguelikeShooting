using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Weponを生成する
/// </summary>
public class WeaponSpawner : MonoBehaviour
{
    [Header("Wepon")]
    [SerializeField, Tooltip("生成するWepon1")] WeaponSword _weapon;

    [Header("生成する場所")]

    [Tooltip("経過時間")] float _timer;
    public float Timer => _timer;

    ObjectPool<WeaponSword> _weaponPool1;
    void Start()
    {
        _timer = _weapon._timer;
        _weaponPool1 = new ObjectPool<WeaponSword>(_weapon, this.gameObject.transform);

        StartCoroutine(SpownWepon());
    }

    /// <summary>
    /// 武器をスポーンさせる
    /// </summary>
    IEnumerator SpownWepon()
    {
        while (true)
        {
            for(int i = 0; i < _weapon._weaponNum; i++)
            {
                var weapon1 = _weaponPool1.Use();
                weapon1.transform.parent = this.transform;

                Debug.Log($"SwordSpown");
            }
            yield return new WaitForSeconds(Timer);
        }
    }
}
