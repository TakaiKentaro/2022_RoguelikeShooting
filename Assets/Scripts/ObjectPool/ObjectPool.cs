using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
public class ObjectPool<Pool> where Pool : MonoBehaviour , IPool
{   
    [Tooltip("Poolするオブジェクトを入れるリスト")] List<Pool> _pools;
    [Tooltip("Poolさせるオブジェクト")] Pool _type;
    [Tooltip("Poolさせる位置")] Transform _parent;
    [Tooltip("Poolしたい数")] int _poolObjectCount　= 50;

    /// <summary>
    /// セットアップする
    /// </summary>
    /// <param name="pool"></param>
    /// <param name="parent"></param>
    /// <param name="poolObjectCount"></param>
    public ObjectPool(Pool pool, Transform parent = null, int poolObjectCount = 50)
    {
        _pools = new List<Pool>();
        _type = pool;
        _parent = parent;
        _poolObjectCount = 50;

        CreatObj();
    }

    /// <summary>
    /// Poolさせるオブジェクトの作製
    /// </summary>
    void CreatObj()
    {
        for(int i = 0; i < _poolObjectCount; i++)
        {
            Pool p = Object.Instantiate(_type);

            if(_parent != null)
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
    /// 使用する際に呼び出す
    /// </summary>
    /// <returns></returns>
    public Pool Use()
    {
        Pool useObj = _pools.FirstOrDefault(p => p.Waiting);

        if(useObj != null)
        {
            useObj.Waiting = false;
            useObj.IsUseSetUp();
            useObj.StartCoroutine(WaitUsing(useObj));

            return useObj;
        }
        else
        {
            CreatObj();
            return Use();
        }
    }

    /// <summary>
    /// 使用中のupdate
    /// </summary>
    /// <param name="useObj"></param>
    /// <returns></returns>
    IEnumerator<Pool> WaitUsing(Pool useObj)
    {
        while(useObj.Execute())
        {
            yield return null;
        }

        useObj.Delete();
        useObj.Waiting = true;
    }
}
