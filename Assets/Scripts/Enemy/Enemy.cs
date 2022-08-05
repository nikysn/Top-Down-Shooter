using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _startingHealth;
    [SerializeField] private int _reward;
    [SerializeField] private Animator _animator;
    [SerializeField] private Player _target;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private List<GameObject> _corpsesEnemy;

    private float _currentHealth;
    public Player Target => _target;
    public int StartingHealth => _startingHealth;
    public Animator Animator => _animator;

    private Rigidbody2D _rigidbody;

    private void OnEnable()
    {
        _currentHealth = _startingHealth;
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    public void TakeDamage(float damage, float bulletForce)
    {
        _currentHealth -= damage;
        _rigidbody.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);

        if (_currentHealth <= 0)
        {
           /* int numberCorpsesBird = UnityEngine.Random.Range(0, _corpsesEnemy.Count);
            GameObject corpseBird = Instantiate(_corpsesEnemy[numberCorpsesBird], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(corpseBird, 10f);*/
            _spawner.KillEnemy(this);
        }
    }

    public void Init(Player target, Spawner spawner)
    {
        _target = target;
        _spawner = spawner;
    }
}
