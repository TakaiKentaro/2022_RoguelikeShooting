using UnityEngine;

/// <summary>
/// 簡易的なBulletを飛ばすクラス
/// </summary>

public class Bullet : MonoBehaviour, IPool
{
    float _timer;

    Rigidbody _rb;

    // Note. いじらなくてよし. 使用中かどうかの判定を行っている。
    public bool Waiting { get; set; }

    /// <summary>
    /// 生成時の初期化. Start関数
    /// </summary>
    /// <param name="parent">親Object</param>
    public void SetUp(Transform parent)
    {
        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false;

        gameObject.SetActive(false);
    }

    /// <summary>
    /// Useした際の初期化. Start関数
    /// </summary>
    public void IsUseSetUp()
    {
        _timer = 0;
        gameObject.SetActive(true);
        
        _rb.AddForce(Vector2.right * 5, ForceMode.Impulse);
    }

    /// <summary>
    /// 使用中の処理. Update関数
    /// </summary>
    /// <returns></returns>
    public bool Execute()
    {
        _timer += Time.deltaTime;

        if (_timer < 5) return true;
        else return false;
    }

    /// <summary>
    /// Executeがおわった際の処理, Destroy関数
    /// </summary>
    public void Delete()
    {
        gameObject.SetActive(false);
    }
}
