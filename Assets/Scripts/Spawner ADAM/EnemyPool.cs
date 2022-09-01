using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] Enemy _enemyPrefab;
    [SerializeField] Corpse[] _corpsePrefabs;
    [SerializeField] Item[] _itemPrefabs;
    [SerializeField] private float _spawnCount;
    [SerializeField] private float _enemyMultiplier;

    private Pool<Enemy> _enemyPool;
    private List<Pool<Corpse>> _corpsePools = new List<Pool<Corpse>>();
    private List<Pool<Item>> _itemsPools = new List<Pool<Item>>();

    private void Awake()
    {
        _enemyPool = new Pool<Enemy>(_enemyPrefab, transform);

        foreach (Corpse corpsePrefab in _corpsePrefabs)
        {
            if (corpsePrefab != null)
                _corpsePools.Add(new Pool<Corpse>(corpsePrefab, transform));
        }

        foreach (Item itemPrefab in _itemPrefabs)
        {
            if (itemPrefab != null)
                _itemsPools.Add(new Pool<Item>(itemPrefab, transform));
        }
    }

    public Enemy GetEnemy()
    {
        return _enemyPool.GetEnemy(_spawnCount);
    }

    public Corpse GetRandomCorpse()
    {
        int randomCorpseIndex = Random.Range(0, _corpsePools.Count);
        Pool<Corpse> corpsePool = _corpsePools[randomCorpseIndex];
        return corpsePool.GetCorpseAndItem(_spawnCount);
    }

    public Item GetRandomItem()
    {
        int randomItemIndex = Random.Range(0, _itemsPools.Count);
        Pool<Item> itemPool = _itemsPools[randomItemIndex];
        return itemPool.GetCorpseAndItem(_spawnCount);
    }

    public void AddEnemy()
    {
        _spawnCount *=_enemyMultiplier;
    }
}
