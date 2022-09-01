using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class EnemyAnimation : MonoBehaviour
{
    private Animator _animator;
    private const string Attack = "Attack";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void ÑhangeAnimationAttack(bool AttackEnabled)
    {
         _animator.SetBool(Attack, AttackEnabled);
    }
}
