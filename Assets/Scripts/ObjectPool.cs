using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Header("�v�[������I�u�W�F�N�g")]
    [SerializeField, Tooltip("PoolObject")] GameObject _poolObject;
    [SerializeField, Tooltip("�v�[����������")] int _poolObjectNum;
    [SerializeField,Tooltip("PoolObject�̃��X�g")] List<GameObject> _poolObjects = new List<GameObject>();
    void Start()
    {
        StartSpownPoolObject(_poolObjectNum);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// �X�^�[�g����_poolObject�𐶐�
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
    /// �v���C���[���e���擾����֐�
    /// </summary>
    /// <returns></returns>
    public GameObject GetPoolObject()
    {
        for(int i = 0; i < _poolObjects.Count; i++)
        {
            if(_poolObjects[i].activeInHierarchy == false) //_poolObject��i�Ԗڂ���A�N�e�B�u�Ȃ�ʂ�
            {
                return _poolObjects[i];
            }
        }
        return null; //PoolObject���S�Ďg���Ă�����null��Ԃ�
    }
}
