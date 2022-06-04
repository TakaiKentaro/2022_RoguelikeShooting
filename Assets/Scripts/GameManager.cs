using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameManager�N���X
/// </summary>
public class GameManager : MonoBehaviour
{
    static private GameManager _instance = new GameManager();
    static public GameManager Instance => _instance;
    private GameManager() { }


    [Tooltip("�v���C���[")] PlayerController _player;
    public void SetPlayer(PlayerController p) { _player = p; }
    [Tooltip("�|�����G�̐�")] int _killCount;
    [Tooltip("�v���C���[�̃��x��")] int _level = 1;
    [Tooltip("���x���A�b�v�ɕK�v�Ȍo���l")] int _exp = 10;
    /// <summary>
    /// �N���X�^�����擾�����Ƃ��̏���
    /// </summary>
    public void Exp()
    {

    }

    /// <summary>
    /// Enemy��|�����Ƃ��ĂԊ֐�
    /// </summary>
    public void KillCount()
    {
        _killCount++;
    }

    static public PlayerController Player => _instance._player;
}
