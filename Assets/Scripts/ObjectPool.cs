using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Header("プールするオブジェクト")]
    [SerializeField, Tooltip("PoolObject")] GameObject _poolObject;
    [SerializeField, Tooltip("プールしたい数")] int _poolObjectNum;
    [SerializeField,Tooltip("PoolObjectのリスト")] List<GameObject> _poolObjects = new List<GameObject>();
    void Start()
    {
        StartSpownPoolObject(_poolObjectNum);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// スタート時に_poolObjectを生成
    /// </summary>
    /// <param name="num"></param>
    void StartSpownPoolObject(int num)
    {
        for(int i = 0; i < num; i++)
        {
            GameObject go = Instantiate(_poolObject,this.transform);
            go.SetActive(false);
            _poolObjects.Add(go);
        }
    }

    /// <summary>
    /// プレイヤーが弾を取得する関数
    /// </summary>
    /// <returns></returns>
    public GameObject GetPoolObject()
    {
        for(int i = 0; i < _poolObjects.Count; i++)
        {
            if(_poolObjects[i].activeInHierarchy == false) //_poolObjectのi番目が非アクティブなら通る
            {
                return _poolObjects[i];
            }
        }
        return null; //PoolObjectが全て使われていたらnullを返す
    }
}
