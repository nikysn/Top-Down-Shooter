using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(WaveControl))]
[RequireComponent(typeof(Score))]
public class SpawnerAdam : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private float _interval = 1;
    [SerializeField] private float _deathShowTime = 5;
    [SerializeField] private float _deathShowTimeItem = 15;
    [SerializeField] private Transform[] _spawnPoints;

    private Score _score;
    private WaveControl _waveControl;
    private WaitForSeconds _sleep;
    private Coroutine _coroutine;

    private void Awake()
    {
        _waveControl = GetComponent<WaveControl>();
        _score = GetComponent<Score>();
        _sleep = new WaitForSeconds(_interval);
    }

    private void Start()
    {
        StartSpawnCoroutine(_waveControl._birdPool);
    }

    public IEnumerator SpawnCoroutine(EnemyPool enemyPool)
    {
        while (true)
        {
            SpawnObjects(enemyPool);
            yield return _sleep;
        }
    }
    
    public void StartSpawnCoroutine(EnemyPool enemyPool)
    {
        _coroutine = StartCoroutine(SpawnCoroutine(enemyPool));
    }

    private void SpawnObjects(EnemyPool enemyPool)
    {
        Enemy enemy = enemyPool.GetEnemy();
        _waveControl.NextWave += enemy.SetSpeed;

        SpawnEnemy(enemy);

        SpawnCorpse(enemyPool, enemy);

        SpawnItem(enemyPool, enemy);
    }

    private void OnEnemyDeath(Enemy enemy)
    {
        _score.GetScore(enemy);
        enemy.OnDeath -= OnEnemyDeath;
    }

    private void SpawnCorpse(EnemyPool enemyPool, Enemy enemy)
    {
        if (enemy != null && enemy._corpse == null)
        {
            Corpse corpse = enemyPool.GetRandomCorpse();
            corpse.gameObject.SetActive(false);
            corpse.SetDeathShowTime(_deathShowTime);
            enemy.SetCorpse(corpse);
        }
    }

    private void SpawnItem(EnemyPool enemyPool, Enemy enemy)
    {
        if (enemy != null && enemy._item == null)
        {
            Item item = enemyPool.GetRandomItem();

            if (item.GetComponent<Money>())
            {
                _score.Init(item.GetComponent<Money>());
            }

            item.Disable();
            item.SetDeathShowTime(_deathShowTimeItem);
            enemy.SetItem(item);
        }
    }

    private void SpawnEnemy(Enemy enemy)
    {
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
        }
    }
}
