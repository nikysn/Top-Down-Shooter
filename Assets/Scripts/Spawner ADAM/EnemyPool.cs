using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] Enemy _enemyPrefab;
    [SerializeField] Corpse[] _corpsePrefabs;
    [SerializeField] private int _spawnCount;

    private Pool<Enemy> _enemyPool;
    private List<Pool<Corpse>> _corpsePools = new List<Pool<Corpse>>();

    private void Awake()
    {
        _enemyPool = new Pool<Enemy>(_enemyPrefab, transform);

        foreach (Corpse corpsePrefab in _corpsePrefabs)
        {
            if (corpsePrefab != null)
                _corpsePools.Add(new Pool<Corpse>(corpsePrefab, transform));
        }
    }

    public Enemy GetEnemy()
    {
        return _enemyPool.GetItem(_spawnCount);
    }

    public Corpse GetRandomCorpse()
    {
        int randomCorpseIndex = Random.Range(0, _corpsePools.Count);
        Pool<Corpse> corpsePool = _corpsePools[randomCorpseIndex];
        return corpsePool.GetItem(_spawnCount);
    }
}
