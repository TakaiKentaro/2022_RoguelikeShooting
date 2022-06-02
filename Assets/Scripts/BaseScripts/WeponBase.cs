using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MonoBehaviourを継承したとき用に用意
/// </summary>
interface WeponlBase
{
    WeponBase WeponId { get; }
    void Setup();
    void Update();
    void Levelup();
}

/// <summary>
/// 武器の名前と番号をここに追加
/// </summary>
public enum WeponBase
{
    Throwknife = 0,
    Handgun = 1,
    Minecart = 2,
    DamageZone = 3,
    Garlic = 4,
}

