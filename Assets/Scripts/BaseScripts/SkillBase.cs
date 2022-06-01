using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MonoBehaviour���p�������Ƃ��p�ɗp��
/// </summary>
interface SkillBase
{
    SkillDef SkillId { get; }
    void Setup();
    void Update();
    void Levelup();
}

/// <summary>
/// �X�L���̖��O�Ɣԍ��������ɒǉ�
/// </summary>
public enum SkillDef
{
    Throwknife = 0,
    Handgun = 1,
    Minecart = 2,
    DamageZone = 3,
}

