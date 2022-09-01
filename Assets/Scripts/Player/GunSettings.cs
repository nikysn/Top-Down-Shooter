using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "GunSettings", menuName = "Gun Settings", order = 51)]
public class GunSettings : ScriptableObject
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private float _bulletForce;
    [SerializeField] private float _reloadTime;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _playerSpeed;
    [SerializeField] private int _countBullet = 6;

    public Bullet BulletPrefab => _bulletPrefab;
    public Sprite Sprite => _sprite;
    public float BulletForce => _bulletForce;
    public float ReloadTime => _reloadTime;
    public float FireRate => _fireRate;
    public float PlayerSpeed => _playerSpeed;
    public int CountBullet => _countBullet;
}
