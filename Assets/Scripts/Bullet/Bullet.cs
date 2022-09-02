using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _hitEffect;
    [SerializeField] private float _bulletForce = 15f;
    [SerializeField] private float _damage = 15;
    [SerializeField] private float _lifeTimeBullet = 4f;

    private float _rangeRadius = 0.1f;

    private void OnEnable()
    {
        StartCoroutine(LifeTimeBullet());
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            DamageObject();
        }
    }
    public void Enable()
    {
        gameObject.SetActive(true);
    }

    private void DamageEnemy(Enemy enemy)
    {
        if (enemy != null)
        {
            enemy.TakeDamage(_damage, _bulletForce);
        }
    }

    private void Disable()
    {
        if (gameObject != null)
        {
            gameObject.SetActive(false);
        }
    }

    private IEnumerator LifeTimeBullet()
    {
        yield return  new WaitForSeconds(_lifeTimeBullet);
        Disable();
    }
}
