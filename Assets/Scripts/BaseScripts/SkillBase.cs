using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MonoBehaviourを継承したとき用に用意
/// </summary>
interface SkillBase
{
    SkillDef SkillId { get; }
    void Setup();
    void Update();
    void Levelup();
}

/// <summary>
/// スキルの名前と番号をここに追加
/// </summary>
public enum SkillDef
{
    Throwknife = 0,
    Handgun = 1,
    Minecart = 2,
    DamageZone = 3,
}

