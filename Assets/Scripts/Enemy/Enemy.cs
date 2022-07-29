using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    [SerializeField] private Player _target;
    private int _currentHealth;
    private int _bulletForce = 5;
    public Player Target => _target;

    public event UnityAction Dying;

    private Rigidbody2D _rigidbody;

    private void OnEnable()
    {
        _currentHealth = _health;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _rigidbody.AddForce(transform.up * _bulletForce, ForceMode2D.Impulse);

        if (_currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void Init(Player target)
    {
        _target = target;
    }
}
