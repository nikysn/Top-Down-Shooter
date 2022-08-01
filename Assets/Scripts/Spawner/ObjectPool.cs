using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
   // [SerializeField] private GameObject _containerCorpsesEnemy;
    [SerializeField] private int _capacity;
    [SerializeField] Player _target;
    
   


   // public event UnityAction<int, int> EnemyCountChanged;

    protected void Initialize(Enemy prefab,List<Enemy> pools)
    {
        for (int i = 0; i < _capacity; i++)
        {
            Enemy spawned = Instantiate(prefab, _container.transform);
            spawned.Init(_target);
            spawned.gameObject.SetActive(false);
            pools.Add(spawned);
        }
    }

    protected bool TryGetObject(out Enemy result, List<Enemy> pools)
    {
        result = pools.FirstOrDefault(p => p.gameObject.activeSelf == false);

        return result != null;
    }
}
