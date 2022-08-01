using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    [SerializeField] private Player _target;
    [SerializeField] private GameObject[] _corpsesEnemy;
    
    private int _currentHealth;
    private int _bulletForce = 15;
    public Player Target => _target;

    public event UnityAction Dying;

    private Rigidbody2D _rigidbody;

    private void OnEnable()
    {
        _currentHealth = _health;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    public void TakeDamage(int damage)
    {
        
        _currentHealth -= damage;
        _rigidbody.AddForce(transform.up * _bulletForce, ForceMode2D.Impulse);

        if (_currentHealth <= 0)
        {
            int numberCorpsesBird = Random.Range(0, _corpsesEnemy.Length - 1);
            GameObject corpseBird = Instantiate(_corpsesEnemy[numberCorpsesBird],new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
            Destroy(corpseBird, 5f);
            gameObject.SetActive(false);
        }
    }

    public void Init(Player target)
    {
        _target = target;
    }
}
