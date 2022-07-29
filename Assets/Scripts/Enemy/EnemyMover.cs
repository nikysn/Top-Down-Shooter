using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Player _target;
   
    private Rigidbody2D _rigidbody;
    private Vector2 _movement;

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
        _movement = direction;

         _rigidbody.AddForce(direction * _speed);
        // transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
    }

   /* private void MoveCharacter(Vector2 direction)
    {
        _rigidbody.MovePosition((Vector2)transform.position + (direction * _speed * Time.deltaTime));
        //_rigidbody.velocity = new Vector2(_movement.x, _movement.y) * _speed;
    }

    private void FixedUpdate()
    {
        MoveCharacter(_movement);
    }*/
}

