using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float _bulletForce = 20f;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _reloadTime;
    private float _currentTime;
    private int _countBullet = 6;
    private int _currentcountBullet = 6;
    private const string _fire = "Fire1";


    private void Update()
    {
        if (_currentTime <= 0)
        {
            Shoot();

        }
        else
        {
            Reload();
        }
    }

    private void Shoot()
    {
        if (Input.GetButtonDown(_fire))
        {
            Bullet bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
            Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
            rigidbody.AddForce(_firePoint.right * _bulletForce, ForceMode2D.Impulse);
            _currentcountBullet--;

            bullet.GetFirePoint(_firePoint);

            if (_currentcountBullet <= 0)
            {
                _currentTime = _reloadTime;
            }
        }
    }

    private void Reload()
    {
        _currentTime -= Time.deltaTime;
        _currentcountBullet = _countBullet;
    }
}
