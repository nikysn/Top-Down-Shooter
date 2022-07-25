using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;
    [SerializeField] Player _target;
    private List<Enemy> _pools = new List<Enemy>();


    protected void Initialize(Enemy prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            Enemy spawned = Instantiate(prefab, _container.transform);
            spawned.Init(_target);
            spawned.gameObject.SetActive(false);

            _pools.Add(spawned);
        }
    }

    protected bool TryGetObject(out Enemy result)
    {
        result = _pools.FirstOrDefault(p => p.gameObject.activeSelf == false);

        return result != null;
    }

}
