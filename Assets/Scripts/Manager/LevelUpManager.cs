using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ���x���A�b�v�N���X
/// </summary>
public class LevelUpManager : MonoBehaviour
{
    [Header("LevelUpCanvas")]
    [SerializeField, Tooltip("���x���A�b�v�pCanvas")] GameObject _canvas;

    [SerializeField, Tooltip("�X�L���{�^��1")] Button _button1;
    [SerializeField, Tooltip("�X�L���{�^��2")] Button _button2;
    [SerializeField, Tooltip("�X�L���{�^��3")] Button _button3;

    [SerializeField, Tooltip("�X�L���e�L�X�g1")] Text _text1;
    [SerializeField, Tooltip("�X�L���e�L�X�g2")] Text _text2;
    [SerializeField, Tooltip("�X�L���e�L�X�g3")] Text _text3;

}
