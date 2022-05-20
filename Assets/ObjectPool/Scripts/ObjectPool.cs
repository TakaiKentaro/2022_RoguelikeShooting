using UnityEngine;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// Pool��������Object�Ɍp������
/// </summary>
public interface IPool
{
    bool Waiting { get; set; }
    void SetUp(Transform parent);
    void IsUseSetUp();
    bool Execute();
    void Delete();
}

/// <summary>
/// ObjectPool�̊Ǘ��N���X
/// </summary>
/// <typeparam name="Pool">Pool������N���X</typeparam>

public class ObjectPool<Pool> where Pool : MonoBehaviour, IPool 
{
    List<Pool> _pools;
    Pool _type;

    Transform _parent;
    int _createCount;

    /// <summary>
    /// �Z�b�g�A�b�v
    /// </summary>
    /// <param name="pool">Pool������Ώ�</param>
    /// <param name="parent">�eObject�̗L��</param>
    /// <param name="createCount">Pool������</param>
    public ObjectPool(Pool pool, Transform parent = null, int createCount = 10)
    {
        _pools = new List<Pool>();
        _type = pool;
        _parent = parent;
        _createCount = 10;

        Create();
    }

    /// <summary>
    /// �g�p����ۂ̌Ăяo��
    /// </summary>
    /// <returns></returns>
    public Pool Use()
    {
        Pool item = _pools.FirstOrDefault(p => p.Waiting);

        if (item != null)
        {
            item.Waiting = false;
            item.IsUseSetUp();
            item.StartCoroutine(WaitUsing(item));
            return item;
        }
        else
        {
            Create();
            return Use();
        }
    }

    /// <summary>
    /// Pool������Object�̍쐬
    /// </summary>
    void Create()
    {
        for (int i = 0; i < _createCount; i++)
        {
            Pool p = Object.Instantiate(_type);

            if (_parent != null)
            {
                p.transform.SetParent(_parent);
                p.transform.position = _parent.position;
            }

            p.Waiting = true;
            p.SetUp(_parent);

            _pools.Add(p);
        }
    }

    /// <summary>
    /// �g�p����Update
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    IEnumerator<Pool> WaitUsing(Pool item)
    {
        while(item.Execute())
        {
            yield return null;
        }

        item.Delete();
        item.Waiting = true;
    }
}
