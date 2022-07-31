using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class EnemyAnimation : MonoBehaviour
{
    private EnemyMover _enemyMover;
    private Animator _animator;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void ÑhangeAnimationAttack(bool AttackEnabled)
    {
         _animator.SetBool("Attack", AttackEnabled);
    }
}
