using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MonoBehaviour���p�������Ƃ��p�ɗp��
/// </summary>
interface WeponlBase
{
    WeponBase WeponId { get; }
    void Setup();
    void Update();
    void Levelup();
}

/// <summary>
/// ����̖��O�Ɣԍ��������ɒǉ�
/// </summary>
public enum WeponBase
{
    Throwknife = 0,
    Handgun = 1,
    Minecart = 2,
    DamageZone = 3,
    Garlic = 4,
}

