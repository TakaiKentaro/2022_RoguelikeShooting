using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameManager�N���X
/// </summary>
public class GameManager : MonoBehaviour
{
    static private GameManager _instance = null;
    static public GameManager Instance => _instance;
    //private GameManager() { }


    [Tooltip("�v���C���[")] PlayerController _player;
    public void SetPlayer(PlayerController p) { _player = p; }
    [Tooltip("�|�����G�̐�")] int _killCount;

    [Tooltip("�v���C���[�̃��x��")] int _level = 1;
    [Tooltip("�o���l�̍��v��ۑ�")] int _saveExp = 0;
    [Tooltip("���x���A�b�v�ɕK�v�Ȍo���l")] int _expMaxValue = 10;

    private void Awake()
    {
        if(!_instance)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }

    private void OnDestroy()
    {
        if(_instance == this)
        {
            _instance = null;
        }
    }

    /// <summary>
    /// �N���X�^�����擾�����Ƃ��̏���
    /// </summary>
    public void Exp(int exp)
    {
        Debug.Log("�o���l�A�b�v");
        _saveExp += exp;
        if(_saveExp >= _expMaxValue)
        {
            _level++;
            _saveExp = 0;
            _expMaxValue += 10;
        }
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
