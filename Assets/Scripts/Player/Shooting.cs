using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float _bulletForce = 20f;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bulletPrefab;


    private void Shoot()
    {
        GameObject bullet =  Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(_firePoint.right * _bulletForce, ForceMode2D.Impulse);
    }
    
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
}
