using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _currentHealth;
    [SerializeField] private Sprite _spriteTwoHandedWeapon;
    [SerializeField] private Sprite _spriteOneHandedWeapon;

    private SpriteRenderer _spriteRenderer;

    public event UnityAction<float> HealthChanged;
    public event UnityAction Die;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
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
            Die?.Invoke();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<OneHandedWeapon>(out OneHandedWeapon weapon))
        {
            _spriteRenderer.sprite = _spriteOneHandedWeapon;
        }

        if (collision.TryGetComponent<TwoHandedWeapon>(out TwoHandedWeapon tweapon))
        {
            _spriteRenderer.sprite = _spriteTwoHandedWeapon;
        }
    }
}
