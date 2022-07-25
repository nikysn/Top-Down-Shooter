using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _hitEffect;
    [SerializeField] private float _bulletForce = 15f;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect =  Instantiate(_hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        GameObject effect = Instantiate(_hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
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
}
