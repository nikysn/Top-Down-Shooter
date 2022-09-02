using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Enemy))]
public class MoveState : State
{
    [SerializeField] private float _speedMultiplier;
    [SerializeField] private Player _target;
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;

    private void OnEnable()
    {
        _target = GetComponent<Enemy>().Target;
        _rigidbody = GetComponent<Rigidbody2D>();
       
        if (Animator != null)
        {
            Animator.ChangeAnimationAttack(false);
        }
    }

    private void Update()
    {
        if (_target != null)
        {
            Vector3 direction = _target.transform.position - transform.position;
            direction.Normalize();

            transform.up =- direction;
            _rigidbody.AddForce(direction * _speed);
        }
    }

    public void ChangeSpeed(float speed)
    {
        _speed *= speed;
    }
}
