using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSpowner : MonoBehaviour
{
    [Header("Crystal")]
    [SerializeField, Tooltip("ƒNƒŠƒXƒ^ƒ‹")] Crystal _crystal;


    ObjectPool<Crystal> _crystalPool1;
    void Start()
    {
        _crystalPool1 = new ObjectPool<Crystal>(_crystal, this.gameObject.transform); ;
    }

    public void SpownCrystal(Transform tf)
    {
        var crystal = _crystalPool1.Use();
        crystal.transform.position = new Vector3(tf.position.x, tf.position.y + 1, tf.position.z);
    }
}
