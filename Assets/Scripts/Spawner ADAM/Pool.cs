using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pool<T> where T : MonoBehaviour
{
    private T _prefab;
    private List<T> _objects = new List<T>();
    private Transform _parent;

    public Pool(T prefab, Transform parent)
    {
        _prefab = prefab;
        _parent = parent;
    }

    public T GetItem(int countItem)
    {
        foreach (var item in _objects)
            if (item.gameObject.activeSelf == false)
                return item;

        if (_objects.Count < countItem )
        {
            var newItem = GameObject.Instantiate(_prefab, _parent);
            _objects.Add(newItem);
            return newItem;
        }

        return null;
    }
}
