using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[ RequireComponent(typeof(Rigidbody))]
[ RequireComponent(typeof(MoveState))]
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private int _damage;
    [SerializeField] private int _startingHealth;
    [SerializeField] private float _speedMultiplier = 1.2f;
    private Rigidbody2D _rigidbody;
    private float _currentHealth;

    public Corpse _corpse { get; private set; }
    public MoveState MoveState { get; private set; }
    public Item _item { get; private set; }
    public Player Target => _target;
    public int StartingHealth => _startingHealth;

    public event Action<Enemy> OnDeath;

    private void OnEnable()
    {
        MoveState = GetComponent<MoveState>();
        _currentHealth = _startingHealth;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    public void TakeDamage(float damage, float bulletForce)
    {
        _currentHealth -= damage;
        var direction =- (_target.transform.position - transform.position).normalized;
        _rigidbody.AddForce(direction * bulletForce, ForceMode2D.Impulse);

        if (_currentHealth <= 0)
        {
            Disable();
        }
    }

    public void Init(Player target)
    {
        _target = target;
    }

    public void SetCorpse(Corpse corpse)
    {
        if (_corpse == null)
        {
            _corpse = corpse;
        }
    }

    public void SetItem(Item item)
    {
        if (_item == null)
        {
            _item = item;
        }
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    private void Disable()
    {
        OnDeath?.Invoke(this);
        _corpse.ShowInPosition(transform.position);
        _item.ShowInPosition(transform.position);
        gameObject.SetActive(false);
    }

    public void SetSpeed()
    {
        MoveState.ChangeSpeed(_speedMultiplier);
    }
}
