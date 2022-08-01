using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private Transform[] _spawnPoints;
    private List<Enemy> _poolsBird = new List<Enemy>();

    private float _elapserTime = 0;

    private void SetEnemy(Enemy enemy, Vector3 spawnPoint)
    {
        enemy.gameObject.SetActive(true);

        enemy.transform.position = spawnPoint;
    }

    private void Start()
    {
        Initialize(_enemyPrefab, _poolsBird);
    }

    private IEnumerator SpawningEnemy()
    {

        if (TryGetObject(out Enemy enemy, _poolsBird))
        {
            
            int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

            SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);
            yield return new WaitForSeconds(5f);

        }
        // if (TryGetObject(out Enemy enemy, _poolsBird))
        // {
        // _elapserTime = 0;



        // }
    }

    private void Update()
    {
        /* _elapserTime += Time.deltaTime;

         if (_elapserTime >= _secondsBetweenSpawn)
         {
             if (TryGetObject(out Enemy enemy, _poolsBird))
             {
                 _elapserTime = 0;

                 int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

                 SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);

             }
         }*/

        
    }

}
