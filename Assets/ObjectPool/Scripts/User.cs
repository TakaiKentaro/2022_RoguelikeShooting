using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    [SerializeField] Bullet _bullet;
    ObjectPool<Bullet> _bulletPool;

    void Start()
    {
        _bulletPool = new ObjectPool<Bullet>(_bullet, null);
    }

    public void OnCleck()
    {
        var bullet = _bulletPool.Use();
        bullet.transform.position = transform.position;
    }
}
