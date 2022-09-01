using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] Bullet _bulletPrefab;

    private Pool<Bullet> _bulletPool;

    private void Awake()
    {
        _bulletPool = new Pool<Bullet>(_bulletPrefab, transform);
    }

    public Bullet GetBullet()
    {
        return _bulletPool.GetBullet();
    }
}
