using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private List<Weapon> _weapons;

    public int Money { get; private set; }
    private Weapon _currentWeapon;
    [SerializeField] private int _currentHealth;
    private Animator _animator;

    public event UnityAction<float> HealthChanged;

    private void Start()
    {
        _currentWeapon = _weapons[0];
        
        _animator = GetComponent<Animator>();
    }
    private void Awake()
    {
        _currentHealth = _health;
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth);

        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

}
