using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _containerEnemy;
    [SerializeField] private GameObject _containerCorpses;
    
    [SerializeField] private int _capacity;
    [SerializeField] Player _target;
    [SerializeField] Spawner _spawner;
    
    protected void Initialize(Enemy enemyPrefab,List<GameObject> corpsePool, List<Enemy> enemyPool)
    {
        for (int i = 0; i < _capacity; i++)
        {
            Enemy enemy = Instantiate(enemyPrefab, _containerEnemy.transform);
            enemy.Init(_target, _spawner);
            enemy.gameObject.SetActive(false);
            enemyPool.Add(enemy);

            int randomCorpse = Random.Range(0, corpsePool.Count);
            GameObject corpses = Instantiate(corpsePool[randomCorpse], _containerCorpses.transform);
            corpses.gameObject.SetActive(false);
            corpsePool.Add(corpses);
        }
    }

    protected bool TryGetObject(out Enemy result, List<Enemy> pools )
    {
        result = pools.FirstOrDefault(p => p.gameObject.activeSelf == false);

        return result != null;
    }

    protected bool TryGetObjectCorpse(out GameObject result, List<GameObject> pools)
    {
        result = pools.FirstOrDefault(p => p.gameObject.activeSelf == false);

        return result != null;
    }
}
