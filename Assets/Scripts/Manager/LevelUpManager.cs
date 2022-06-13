using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ���x���A�b�v�N���X
/// </summary>
public class LevelUpManager : MonoBehaviour
{
    [Header("LevelUpCanvas")]
    [SerializeField, Tooltip("���x���A�b�v�pCanvas")] GameObject _canvas;

    [SerializeField, Tooltip("�X�L���{�^��1")] Image _button1;
    [SerializeField, Tooltip("�X�L���{�^��2")] Image _button2;
    [SerializeField, Tooltip("�X�L���{�^��3")] Image _button3;

    [SerializeField, Tooltip("�X�L���e�L�X�g1")] Text _text1;
    [SerializeField, Tooltip("�X�L���e�L�X�g2")] Text _text2;
    [SerializeField, Tooltip("�X�L���e�L�X�g3")] Text _text3;

    private void Start()
    {
        _button1 = GetComponent<Image>();
        _button2 = GetComponent<Image>();
        _button3 = GetComponent<Image>();
        _text1 = GetComponent<Text>();
        _text2 = GetComponent<Text>();
        _text3 = GetComponent<Text>();

        _canvas.gameObject.SetActive(false);
    }

    /// <summary>
    /// ���x���A�b�v�������̏���
    /// </summary>
    public void LevelUp()
    {

    }

}
