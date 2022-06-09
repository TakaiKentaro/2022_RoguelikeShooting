using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Wepon�𐶐�����
/// </summary>
public class WeaponSpawner : MonoBehaviour
{
    [Header("Wepon")]
    [SerializeField, Tooltip("��������Wepon1")] Weapon _wepon1;

    [Tooltip("�o�ߎ���")] float _timer;
    public float Timer => _timer;

    ObjectPool<Weapon> _weaponPool1;
    void Start()
    {
        _weaponPool1 = new ObjectPool<Weapon>(_wepon1, this.gameObject.transform);

        StartCoroutine(SpownWepon());
    }

    /// <summary>
    /// ������X�|�[��������
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
