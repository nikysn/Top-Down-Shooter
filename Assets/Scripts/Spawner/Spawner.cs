using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private Transform[] _spawnPoints;

    private float _elapserTime = 0;

    private void SetEnemy(Enemy enemy, Vector3 spawnPoint)
    {
        enemy.gameObject.SetActive(true);

        enemy.transform.position = spawnPoint;
    }

    private void Start()
    {
        Initialize(_enemyPrefab);
    }

    private void Update()
    {
        _elapserTime += Time.deltaTime;

        if (_elapserTime >= _secondsBetweenSpawn)
        {
            if (TryGetObject(out Enemy enemy))
            {
                _elapserTime = 0;

                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
                
                SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);
 
            }
        }
    }

}
