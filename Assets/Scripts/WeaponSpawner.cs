using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Weponを生成する
/// </summary>
public class WeaponSpawner : MonoBehaviour
{
    [Header("Wepon")]
    [SerializeField, Tooltip("生成するWepon1")] Weapon _wepon1;

    [Tooltip("経過時間")] float _timer;
    public float Timer => _timer;

    ObjectPool<Weapon> _weaponPool1;
    void Start()
    {
        _weaponPool1 = new ObjectPool<Weapon>(_wepon1, this.gameObject.transform);

        StartCoroutine(SpownWepon());
    }

    /// <summary>
    /// 武器をスポーンさせる
    /// </summary>
    IEnumerator SpownWepon()
    {
        while (true)
        {
            var weapon1 = _weaponPool1.Use();
            weapon1.transform.parent = this.transform;

            yield return new WaitForSeconds(Timer);
        }
    }
}
