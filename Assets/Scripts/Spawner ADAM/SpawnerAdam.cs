using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class SpawnerAdam : MonoBehaviour
{
    [SerializeField] EnemyPool _enemyPool;
    [SerializeField] EnemyPool _fatsoPool;
    [SerializeField] Player _target;
    [SerializeField] float _interval = 1;
    [SerializeField] float _deathShowTime = 5;
    [SerializeField] private Transform[] _spawnPoints;

    private Score _score;
    private WaitForSeconds _sleep;
    private Coroutine _spawnJob;

    private void Awake()
    {
        _score = GetComponent<Score>();
        _sleep = new WaitForSeconds(_interval);
    }

    private void Start()
    {
        StartSpawnCoroutine(_enemyPool);
    }

    private void SpawnEnemy(EnemyPool enemyPool)
    {
        Enemy enemy = enemyPool.GetEnemy();
        Vector3 ramdomSpawn = new Vector3(Random.Range(-18f, 18f), Random.Range(-9f, 9f));

        if (enemy != null)
        {
            if (enemy.GetComponent<Bird>())
            {
                enemy.transform.position = _spawnPoints[Random.Range(0, _spawnPoints.Length - 1)].position;
            }
            else
            {
                enemy.transform.position = ramdomSpawn;
            }

            enemy.Enable();
            enemy.OnDeath += OnEnemyDeath;
            enemy.Init(_target);

            Corpse corpse = enemyPool.GetRandomCorpse();
            corpse.gameObject.SetActive(false);
            corpse.SetDeathShowTime(_deathShowTime);
            enemy.SetCorpse(corpse);
        }
    }

    private void OnEnemyDeath(Enemy enemy)
    {
        // TO DO
        _score.GetScore(enemy);
        NextWave(_score.FirstWave, _fatsoPool);
        enemy.OnDeath -= OnEnemyDeath;
    }

    private void StartSpawnCoroutine(EnemyPool enemyPool)
    {
        /* if (_spawnJob != null)
             StopSpawnCoroutine();*/

        StartCoroutine(SpawnCoroutine(enemyPool));
    }

    private void StopSpawnCoroutine()
    {
        StopCoroutine(_spawnJob);
    }

    private IEnumerator SpawnCoroutine(EnemyPool enemyPool)
    {
        while (true)
        {
            SpawnEnemy(enemyPool);
            yield return _sleep;
        }
    }

    private void NextWave(float scoreCount, EnemyPool enemyPool)
    {
        Coroutine coroutine = null;

        if (_score.TotalScore >= scoreCount && coroutine == null)
        {
            _score.ResetCurrentStore();
            coroutine = StartCoroutine(SpawnCoroutine(enemyPool));
        }
    }
}
