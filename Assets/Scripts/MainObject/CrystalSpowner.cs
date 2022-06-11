using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSpowner : MonoBehaviour
{
    [Header("Crystal")]
    [SerializeField, Tooltip("クリスタル")] Crystal _crystal;


    ObjectPool<Crystal> _crystalPool1;
    void Start()
    {
        _crystalPool1 = new ObjectPool<Crystal>(_crystal, this.gameObject.transform); ;
    }

    public void SpownCrystal(Transform tf)
    {
        var crystal = _crystalPool1.Use();
        crystal.transform.position = tf.position;
    }
}
