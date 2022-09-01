using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class Shooting : MonoBehaviour
{
    [SerializeField] private GunSettings _gunSettings;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private Animator _gunAnimator;
    [SerializeField] private BulletPool _bulletPool;

    private SpriteRenderer _spriteRenderer;
    private Bullet _bulletPrefab;
    private float _bulletForce;
    private float _reloadTime;
    private float _fireRate;
    private int _countBullet;
    private int _currentCountBullet = 6;
    private float _readyForNextShot;
    private float _currentTime;

    private const string Fire = "Fire1";
    private const string Shoot = "Shoot";

    public event UnityAction<float> ChangeSpeed;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (_currentTime <= 0)
        {
            TakeShoot();
        }
        else
        {
            Reload();
        }
    }

    public void SetGunSettings(GunSettings gunSettings)
    {
        _spriteRenderer.sprite = gunSettings.Sprite;
        _bulletForce = gunSettings.BulletForce;
        _bulletPrefab = gunSettings.BulletPrefab;
        _reloadTime = gunSettings.ReloadTime;
        _fireRate = gunSettings.FireRate;
        _countBullet = gunSettings.CountBullet;
        _currentCountBullet = gunSettings.CountBullet;
        ChangeSpeed?.Invoke(gunSettings.PlayerSpeed);
    }

    private void OnEnable()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        SetGunSettings(_gunSettings);
    }

    private void TakeShoot()
    {
        if (Input.GetButton(Fire))
        {
            if (Time.time > _readyForNextShot)
            {
                _readyForNextShot = Time.time + 1 / _fireRate;

                Bullet bullet = _bulletPool.GetBullet();
                bullet.transform.position = _firePoint.position;
                bullet.Enable();
                Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
                rigidbody.AddForce(_firePoint.right * _bulletForce, ForceMode2D.Impulse);
                _currentCountBullet--;

                _gunAnimator.SetTrigger(Shoot);

                if (_currentCountBullet <= 0)
                {
                    _currentTime = _reloadTime;
                }
            }
        }
    }

    private void Reload()
    {
        _currentTime -= Time.deltaTime;
        _currentCountBullet = _countBullet;
    }
}
