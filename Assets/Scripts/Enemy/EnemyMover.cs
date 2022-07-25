using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Player _target;
   
    private Rigidbody2D _rigidbody;
    private Vector2 _movement;
    private bool _bulletInTrigger = false;

    private void OnEnable()
    {
        _target = GetComponent<Enemy>().Target;
        _rigidbody = GetComponent<Rigidbody2D>();
    }



    /*public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Bullet>(out Bullet bullet))
        {
            _rigidbody.AddForce(bullet.transform.right * _bulletForce, ForceMode2D.Impulse);
            Debug.Log("в тригере");
           // _bulletInTrigger = true;
           // StartCoroutine(ChangeVolume());
            
        }

    }*/

    private IEnumerator ChangeVolume()
    {
        yield return new WaitForSeconds(0.2f);
        _bulletInTrigger = false;
    }

    private void MoveCharacter(Vector2 direction)
    {
        if (_bulletInTrigger == false)
        {
            _rigidbody.MovePosition((Vector2)transform.position + (direction * _speed * Time.deltaTime));
            //_rigidbody.velocity = new Vector2(_movement.x, _movement.y) * _speed;

        }


    }

    private void Update()
    {
        Vector3 direction = _target.transform.position - transform.position;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _rigidbody.rotation = angle;
        _movement = direction;

         _rigidbody.AddForce(direction * _speed);
        // transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
       // MoveCharacter(_movement);
    }
}

