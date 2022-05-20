using UnityEngine;

/// <summary>
/// �ȈՓI��Bullet���΂��N���X
/// </summary>

public class Bullet : MonoBehaviour, IPool
{
    float _timer;

    Rigidbody _rb;

    // Note. ������Ȃ��Ă悵. �g�p�����ǂ����̔�����s���Ă���B
    public bool Waiting { get; set; }

    /// <summary>
    /// �������̏�����. Start�֐�
    /// </summary>
    /// <param name="parent">�eObject</param>
    public void SetUp(Transform parent)
    {
        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false;

        gameObject.SetActive(false);
    }

    /// <summary>
    /// Use�����ۂ̏�����. Start�֐�
    /// </summary>
    public void IsUseSetUp()
    {
        _timer = 0;
        gameObject.SetActive(true);
        
        _rb.AddForce(Vector2.right * 5, ForceMode.Impulse);
    }

    /// <summary>
    /// �g�p���̏���. Update�֐�
    /// </summary>
    /// <returns></returns>
    public bool Execute()
    {
        _timer += Time.deltaTime;

        if (_timer < 5) return true;
        else return false;
    }

    /// <summary>
    /// Execute����������ۂ̏���, Destroy�֐�
    /// </summary>
    public void Delete()
    {
        gameObject.SetActive(false);
    }
}
