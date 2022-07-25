using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    [SerializeField] private Player _target;
    
    public Player Target => _target;
    

    public event UnityAction Dying;


    public void TakeDamage(int damage)
    {
        _health -= damage;

        if(_health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void Init(Player target)
    {
        _target = target;
    }

   
    

}
