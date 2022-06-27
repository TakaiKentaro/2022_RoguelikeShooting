using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
/// <typeparam name="TPool">Pool������N���X</typeparam>
public class ObjectPool<TPool> where TPool : MonoBehaviour , IPool
{
    /// <summary> Pool����I�u�W�F�N�g�����郊�X�g </summary>
    List<TPool> _pools;
    [Tooltip("Pool������I�u�W�F�N�g")] TPool _type;
    [Tooltip("Pool������ʒu")] Transform _parent;
    [Tooltip("Pool��������")] int _poolObjectCount�@= 100;

    /// <summary>
    /// �Z�b�g�A�b�v����
    /// </summary>
    /// <param name="pool"></param>
    /// <param name="parent"></param>
    /// <param name="poolObjectCount"></param>
    public ObjectPool(TPool pool, Transform parent = null, int poolObjectCount = 100)
    {
        _pools = new List<TPool>();
        _type = pool;
        _parent = parent;
        _poolObjectCount = 100;

        CreatObj();
    }

    /// <summary>
    /// Pool������I�u�W�F�N�g�̍쐻
    /// </summary>
    void CreatObj()
    {
        for(int i = 0; i < _poolObjectCount; i++)
        {
            TPool p = Object.Instantiate(_type);

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
    /// �g�p����ۂɌĂяo��
    /// </summary>
    /// <returns></returns>
    public TPool Use()
    {
        TPool useObj = _pools.FirstOrDefault(p => p.Waiting);

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
    /// �g�p����update
    /// </summary>
    /// <param name="useObj"></param>
    /// <returns></returns>
    IEnumerator<TPool> WaitUsing(TPool useObj)
    {
        while(useObj.Execute())
        {
            yield return null;
        }

        useObj.Delete();
        useObj.Waiting = true;
    }
}
