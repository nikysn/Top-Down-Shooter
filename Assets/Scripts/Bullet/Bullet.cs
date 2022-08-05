using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _hitEffect;
    [SerializeField] private float _bulletForce = 15f;
    [SerializeField] private float _damage = 15;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _lifeTime = 3f;

    public LayerMask toHit;

    private float _rangeRadius = 0.1f;

    public void GetFirePoint(Transform firePoint)
    {
        _firePoint = firePoint;
    }

    public void Die()
    {
        _lifeTime -= Time.deltaTime;

        if (_lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        DamageObject();
        Die();
    }

    public void DamageObject()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        if (_firePoint != null)
        {
            Vector2 firePointPosition = new Vector2(_firePoint.position.x, _firePoint.position.y);
            RaycastHit2D raycastHit2D = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, toHit);
            Vector2 dir = raycastHit2D.point - (Vector2)transform.position;

        }

        //  float dist = _bulletForce * Time.deltaTime;

        // if (_rangeRadius > 0)
        // {
        Collider2D[] collider2D = Physics2D.OverlapCircleAll(transform.position, _rangeRadius);


        foreach (Collider2D col in collider2D)
        {
            if (col.TryGetComponent(out Enemy enemy))
            {
                DamageEnemy(enemy);
                GameObject effect = Instantiate(_hitEffect, transform.position, Quaternion.identity);
                Destroy(effect, 0.5f);
                Destroy(gameObject);
                break;
            }
            /* else if (dir.magnitude <= dist)
             {
                 if (raycastHit2D.collider != null)
                 {
                     Enemy enemy = raycastHit2D.collider.GetComponent<Enemy>();

                     if (enemy != null)
                     {
                         Debug.Log(collider2D.Length);
                         enemy.TakeDamage(_damage);
                         Destroy(gameObject);
                     }
                 }
             }*/
            // }
        }
    }



    /* public void OnCollisionEnter2D(Collision2D collision)
     {
         GameObject effect =  Instantiate(_hitEffect, transform.position, Quaternion.identity);
         Destroy(effect, 0.5f);
         Destroy(gameObject);
     }

     public void OnTriggerEnter2D(Collider2D collision)
     {
         GameObject effect = Instantiate(_hitEffect, transform.position, Quaternion.identity);
         Destroy(effect, 0.5f);
         Destroy(gameObject);

         List<Enemy> _enemies = new List<Enemy>();

         if (collision.TryGetComponent<Enemy>(out Enemy enemy))
         {

             _enemies.Add(enemy);

            // enemy.GetComponent<Rigidbody2D>().AddForce(- enemy.transform.right * _bulletForce, ForceMode2D.Impulse);
            //  Debug.Log("в тригере");
         }

         foreach(var bird in _enemies)
         {
             //Debug.Log(bird.name);
         }

         Debug.Log(_enemies.Count);
     }

     */

    private void DamageEnemy(Enemy enemy)
    {

        if (enemy != null)
        {
            enemy.TakeDamage(_damage,_bulletForce);
        }
    }
}
