using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy�̊��N���X
/// </summary>
public class EnemyBase : MonoBehaviour
{
    [Header("�X�e�[�^�X")]
    [SerializeField, Tooltip("�G�l�~�[�̗̑�")] byte _enemyHp;
    [SerializeField, Tooltip("�G�l�~�[�̍U����")] byte _enemyPower;
    [SerializeField,Tooltip("�G�l�~�[�̃X�s�[�h")] byte _enemySpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
