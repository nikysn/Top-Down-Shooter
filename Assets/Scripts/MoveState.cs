using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Enemy))]
public class MoveState : State
{
   // [SerializeField] private float _speedMultiplier;
    [SerializeField] private Player _target;

    private Rigidbody2D _rigidbody;
    [SerializeField] public float Speed { get; set; }

    

    private void OnEnable()
    {
        _target = GetComponent<Enemy>().Target;
        _rigidbody = GetComponent<Rigidbody2D>();
       
        if (Animator != null)
        {
            Animator.ÑhangeAnimationAttack(false);
        }
    }

    private void Update()
    {
        if (_target != null)
        {
            Vector3 direction = _target.transform.position - transform.position;
            direction.Normalize();

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
            _rigidbody.rotation = angle;
            _rigidbody.AddForce(direction * Speed);
        }
    }

    public void ChangeSpeed(float speed)
    {
        Speed *= speed;
    }
}
