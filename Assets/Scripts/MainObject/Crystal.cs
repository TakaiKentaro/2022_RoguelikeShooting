using UnityEngine;

public class Crystal : MonoBehaviour, IPool
{
    [Header("�o���l")]
    [SerializeField, Tooltip("������o���l")] int _exp;

    [Tooltip("Audio")] AudioManager _source;

    [Tooltip("����")] bool _check = true;
    public bool Waiting { get; set; }

    /// <summary>
    /// �������̏�����. Start�֐�
    /// </summary>
    /// <param name="parent">�eObject</param>
    public void SetUp(Transform parent)
    {
        _source = GameObject.Find("GetSE").GetComponent<AudioManager>();
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Use�����ۂ̏�����. Start�֐�
    /// </summary>
    public void IsUseSetUp()
    {
        gameObject.SetActive(true);
    }

    /// <summary>
    /// �g�p���̏���. Update�֐� true���Ԃ������葱����
    /// </summary>
    /// <returns></returns>
    public bool Execute()
    {
        return _check;
    }

    /// <summary>
    /// Execute����������ۂ̏���, Destroy�֐�
    /// </summary>
    public void Delete()
    {
        _check = true;
        gameObject.SetActive(false);
    }

    /// <summary>
    /// �v���C���[������������
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            Debug.Log("�N���X�^���擾");
            GameManager.Instance.Exp(_exp);
            _source.ClickAudio();
            _check = false;
        }
    }
}
