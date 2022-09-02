using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
   
    private Player _target;
    private Rigidbody2D _rigidbody;

    private void OnEnable()
    {
        _target = GetComponent<Enemy>().Target;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 direction = _target.transform.position - transform.position;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
        _rigidbody.rotation = angle;

         _rigidbody.AddForce(direction * _speed);
    }
}

