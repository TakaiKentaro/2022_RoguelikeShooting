using UnityEngine;

/// <summary>
/// GameManager�N���X
/// </summary>
public class GameManager : MonoBehaviour
{
    static private GameManager _instance = null;
    static public GameManager Instance => _instance;
    //private GameManager() { }

    static public PlayerController Player => _instance._player;
    static public LevelUpManager LevelUpManager => _instance._levelUpManager;
    static public InGameManager InGameManager => _instance._inGameManager;

    [Tooltip("�v���C���[")] PlayerController _player;
    public void SetPlayer(PlayerController p) { _player = p; }

    [Tooltip("���x���A�b�v�}�l�[�W���[")] LevelUpManager _levelUpManager;
    public void SetLevelManager(LevelUpManager lev) { _levelUpManager = lev; }

    [Tooltip("InGame�}�l�[�W���[")] InGameManager _inGameManager;
    public void SetInGameManager(InGameManager ingame) { _inGameManager = ingame; }

    [Tooltip("�|�����G�̐�")] public static int _killCount;
    [Tooltip("�^�C�}�[")] public float _gameTimer;
    [Tooltip("�v���C���[�̃��x��")] public int _level = 1;
    [Tooltip("�o���l�̍��v��ۑ�")] public int _saveExp = 0;
    [Tooltip("���x���A�b�v�ɕK�v�Ȍo���l")] public int _expMaxValue = 5;


    private void Awake()
    {
        if (!_instance)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        _killCount = 0;
    }

    private void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }


    private void Update()
    {
        _gameTimer += Time.deltaTime;
    }

    /// <summary>
    /// �v���C���[�̗̑͂�0�ɂȂ������ɌĂ�
    /// </summary>
    /// <param name="check"></param>
    public void GameOver()
    {
        _inGameManager.ResultScene();
    }

    /// <summary>
    /// �N���X�^�����擾�����Ƃ��̏���
    /// </summary>
    public void Exp(int exp)
    {
        Debug.Log("�o���l�A�b�v");
        _saveExp += exp;
        if (_saveExp >= _expMaxValue)
        {
            Debug.Log("���x���A�b�v");
            _level++;
            _saveExp = 0;
            _expMaxValue += 5;
            _levelUpManager.LevelUp();
            TimeScale();   
        }
    }

    /// <summary>
    /// �Q�[�����Ԑ���
    /// </summary>
    public void TimeScale()
    {
        if (Time.timeScale <= 0.99)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    /// <summary>
    /// Enemy��|�����Ƃ��ĂԊ֐�
    /// </summary>
    public void KillCount()
    {
        _killCount++;
    }
}
