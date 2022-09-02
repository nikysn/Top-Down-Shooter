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

    private const string Fire = "Fire1";
    private const string Shoot = "Shoot";

    public event UnityAction<float> ChangeSpeed;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        StartCoroutine(TakeShoot());
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
        SetGunSettings(_gunSettings);
    }

    private void Reload()
    {
        _currentCountBullet = _countBullet;
    }

    private IEnumerator TakeShoot()
    {
        while (true)
        {
            if (Input.GetButton(Fire))
            {
                var bulletCooldown = new WaitForSeconds(.1f / _fireRate);
                Bullet bullet = _bulletPool.GetBullet();
                bullet.transform.position = _firePoint.position;
                bullet.Enable();
                Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
                rigidbody.AddForce(_firePoint.right * _bulletForce, ForceMode2D.Impulse);
                _currentCountBullet--;

                _gunAnimator.SetTrigger(Shoot);

                yield return bulletCooldown;

                if (_currentCountBullet <= 0)
                {
                    Reload();
                    var reloadCooldown = new WaitForSeconds(_reloadTime);
                    yield return reloadCooldown;
                }
            }
            else
            {
                yield return null;
            }
        }
    }
}
