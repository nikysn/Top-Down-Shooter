using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(Animator))]

public class EnemyAnimation : MonoBehaviour
{
    private EnemyMover _enemyMover;
    private Animator _animator;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _enemyMover = GetComponent<EnemyMover>();
    }

    public void OnAnimationMove()
    {
       // _animator.SetBool(PlayerAnimationController.Params.Run, true);
    }
}
