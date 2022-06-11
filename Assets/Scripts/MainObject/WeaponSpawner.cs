using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Wepon�𐶐�����
/// </summary>
public class WeaponSpawner : MonoBehaviour
{
    [Header("Wepon")]
    [SerializeField, Tooltip("��������Wepon1")] WeaponSword _weapon;

    [Header("��������ꏊ")]

    [Tooltip("�o�ߎ���")] float _timer;
    public float Timer => _timer;

    ObjectPool<WeaponSword> _weaponPool1;
    void Start()
    {
        _timer = _weapon._timer;
        _weaponPool1 = new ObjectPool<WeaponSword>(_weapon, this.gameObject.transform);

        StartCoroutine(SpownWepon());
    }

    /// <summary>
    /// ������X�|�[��������
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
