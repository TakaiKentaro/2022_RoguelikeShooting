using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSpowner : MonoBehaviour
{
    [Header("Crystal")]
    [SerializeField, Tooltip("クリスタル青")] Crystal _crystal1;
    [SerializeField, Tooltip("クリスタル赤")] Crystal _crystal2;
    [SerializeField, Tooltip("クリスタル黒")] Crystal _crystal3;

    ObjectPool<Crystal> _crystalPool1;
    ObjectPool<Crystal> _crystalPool2;
    ObjectPool<Crystal> _crystalPool3;
    void Start()
    {
        _crystalPool1 = new ObjectPool<Crystal>(_crystal1, this.gameObject.transform);
        _crystalPool2 = new ObjectPool<Crystal>(_crystal2, this.gameObject.transform);
        _crystalPool3 = new ObjectPool<Crystal>(_crystal3, this.gameObject.transform);
    }

    public void SpownCrystal(Transform tf, int num)
    {
        if(num == 1)
        {
            var crystal1 = _crystalPool1.Use();
            crystal1.transform.position = new Vector3(tf.position.x, tf.position.y + 1, tf.position.z);
        }
        if(num == 2)
        {
            var crystal2 = _crystalPool2.Use();
            crystal2.transform.position = new Vector3(tf.position.x, tf.position.y + 1, tf.position.z);
        }
        if(num == 3)
        {
            var crystal3 = _crystalPool3.Use();
            crystal3.transform.position = new Vector3(tf.position.x, tf.position.y + 1, tf.position.z);

        }  
    }
}
