using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _hitEffect;
    [SerializeField] private float _bulletForce = 15f;
    [SerializeField] private float _damage = 15;

    private float _rangeRadius = 0.1f;

    private void Update()
    {
        DamageObject();
    }

    public void DamageObject()
    {
        Collider2D[] collider2D = Physics2D.OverlapCircleAll(transform.position, _rangeRadius);

        foreach (Collider2D col in collider2D)
        {
            if (col.TryGetComponent(out Enemy enemy))
            {
                DamageEnemy(enemy);
                GameObject effect = Instantiate(_hitEffect, transform.position, Quaternion.identity);
                Destroy(effect, 0.5f);
                Disable();
                break;
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(_hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
        Disable();
    }

    private void DamageEnemy(Enemy enemy)
    {

        if (enemy != null)
        {
            enemy.TakeDamage(_damage, _bulletForce);
        }
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}
