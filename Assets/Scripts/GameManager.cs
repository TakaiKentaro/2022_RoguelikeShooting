using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameManagerƒNƒ‰ƒX
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Tooltip("“|‚µ‚½“G‚Ì”")] public static int _killEnemyCount;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
}
