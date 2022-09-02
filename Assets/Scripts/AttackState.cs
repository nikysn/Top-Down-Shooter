using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;

    private float _lastAttackTime;

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            Attack();
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack()
    {
        if (Target != null)
        {
            Animator.ChangeAnimationAttack(true);
            Target.ApplyDamage(_damage);
        }
    }
}
