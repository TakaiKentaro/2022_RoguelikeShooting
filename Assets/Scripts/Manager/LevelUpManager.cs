using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ���x���A�b�v�N���X
/// </summary>
public class LevelUpManager : MonoBehaviour
{
    [Header("LevelUpCanvas")]
    [SerializeField, Tooltip("���x���A�b�v�pCanvas")] GameObject _canvas;

    [SerializeField, Tooltip("�X�L���{�^��1")] RectTransform[] _button;

    [Tooltip("�o�͂�����̏��")]int count = 3;

    private void Start()
    {
        GameManager.Instance.SetLevelManager(this);
        foreach(var i in _button) i.gameObject.SetActive(false);
        _canvas.gameObject.SetActive(false);
    }

    /// <summary>
    /// ���x���A�b�v�������̏���
    /// </summary>
    public void LevelUp()
    {
        _canvas.gameObject.SetActive(true);

        while (count-- >= 0)
        {
            int index = Random.Range(0, _button.Length - 1);
            Debug.Log(index);
            if(count == 0)
            {
                _button[index].localPosition = new Vector2(-450,0);
                _button[index].gameObject.SetActive(true);
            }
            if(count == 1)
            {
                _button[index].localPosition = new Vector2(0, 0);
                _button[index].gameObject.SetActive(true);
            }
            if(count == 2)
            {
                _button[index].localPosition = new Vector2(450, 0);
                _button[index].gameObject.SetActive(true);
            }
        }
        count = 3; 
    }

    /// <summary>
    /// Canvas���A�N�e�B�u��
    /// </summary>
    public void OnClickClose()
    {
        foreach (var i in _button) i.gameObject.SetActive(false);
        _canvas.gameObject.SetActive(false);
    }
}
