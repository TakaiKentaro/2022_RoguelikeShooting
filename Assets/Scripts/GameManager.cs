using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameManager�N���X
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Tooltip("�|�����G�̐�")] public static int _killEnemyCount;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
}
