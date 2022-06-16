using UnityEngine;

public class Crystal : MonoBehaviour, IPool
{
    [Header("経験値")]
    [SerializeField, Tooltip("得られる経験値")] int _exp;

    [Tooltip("Audio")] AudioManager _source;

    [Tooltip("判定")] bool _check = true;
    public bool Waiting { get; set; }

    /// <summary>
    /// 生成時の初期化. Start関数
    /// </summary>
    /// <param name="parent">親Object</param>
    public void SetUp(Transform parent)
    {
        _source = GameObject.Find("GetSE").GetComponent<AudioManager>();
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Useした際の初期化. Start関数
    /// </summary>
    public void IsUseSetUp()
    {
        gameObject.SetActive(true);
    }

    /// <summary>
    /// 使用中の処理. Update関数 trueが返る限り周り続ける
    /// </summary>
    /// <returns></returns>
    public bool Execute()
    {
        return _check;
    }

    /// <summary>
    /// Executeがおわった際の処理, Destroy関数
    /// </summary>
    public void Delete()
    {
        _check = true;
        gameObject.SetActive(false);
    }

    /// <summary>
    /// プレイヤーが当たったら
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            Debug.Log("クリスタル取得");
            GameManager.Instance.Exp(_exp);
            _source.ClickAudio();
            _check = false;
        }
    }
}
