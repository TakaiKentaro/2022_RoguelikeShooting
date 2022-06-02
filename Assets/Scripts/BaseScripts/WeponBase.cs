using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MonoBehaviour‚ğŒp³‚µ‚½‚Æ‚«—p‚É—pˆÓ
/// </summary>
interface WeponlBase
{
    WeponBase WeponId { get; }
    void Setup();
    void Update();
    void Levelup();
}

/// <summary>
/// •Ší‚Ì–¼‘O‚Æ”Ô†‚ğ‚±‚±‚É’Ç‰Á
/// </summary>
public enum WeponBase
{
    Throwknife = 0,
    Handgun = 1,
    Minecart = 2,
    DamageZone = 3,
    Garlic = 4,
}

