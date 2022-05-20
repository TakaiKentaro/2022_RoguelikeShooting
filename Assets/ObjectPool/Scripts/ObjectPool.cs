using UnityEngine;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// PoolさせたいObjectに継承する
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
/// ObjectPoolの管理クラス
/// </summary>
/// <typeparam name="Pool">Poolさせるクラス</typeparam>

public class ObjectPool<Pool> where Pool : MonoBehaviour, IPool 
{
    List<Pool> _pools;
    Pool _type;

    Transform _parent;
    int _createCount;

    /// <summary>
    /// セットアップ
    /// </summary>
    /// <param name="pool">Poolさせる対象</param>
    /// <param name="parent">親Objectの有無</param>
    /// <param name="createCount">Poolを作る個数</param>
    public ObjectPool(Pool pool, Transform parent = null, int createCount = 10)
    {
        _pools = new List<Pool>();
        _type = pool;
        _parent = parent;
        _createCount = 10;

        Create();
    }

    /// <summary>
    /// 使用する際の呼び出し
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
    /// PoolさせるObjectの作成
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
    /// 使用中のUpdate
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
