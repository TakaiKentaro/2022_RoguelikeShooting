using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameManagerクラス
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Tooltip("倒した敵の数")] public static int _killEnemyCount;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
}
