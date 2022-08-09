using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class Spawner : ObjectPool
{
    [SerializeField] private Enemy _birdPrefab;
    [SerializeField] private Enemy _fatsoPrefab;

    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _score;
    [SerializeField] private float _totalScore;
    [SerializeField] private Transform[] _spawnPoints;

    private List<Enemy> _poolsBird = new List<Enemy>();
    private List<Enemy> _poolsFatso = new List<Enemy>();
    private List<GameObject> _poolCorpsesBird = new List<GameObject>();
    private List<GameObject> _poolCorpsesFatso = new List<GameObject>();

    private Pool<Enemy> _poolBird;
    private Pool<CorpseBird> _birdCorpse;
    
    private void Awake()
    {
      //  _poolBird = new Pool<Enemy>(_birdPrefab);
      //  _birdCorpse = new Pool<CorpseBird>()
    }

    private Coroutine _coroutine;

    public event UnityAction<float> OnEnemyDeath;

    private void SetEnemy(Enemy enemy, Vector3 spawnPoint)
    {
        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPoint;
    }

    public void KillEnemy(Enemy enemy)
    {
        _score += enemy.StartingHealth;
        TryActivateWave(500);
        OnEnemyDeath?.Invoke(_score);
        _totalScore += enemy.StartingHealth;
        enemy.gameObject.SetActive(false);
        SetCorpse(enemy, _poolCorpsesBird, _poolCorpsesFatso);
    }

    public void SetCorpse(Enemy enemy, List<GameObject> corpsesBird, List<GameObject> corpsesFatso)
    {
        GameObject corpse = null;

        if (enemy is Bird bird)
        {
            if (GetObjectCorpse(out corpse, corpsesBird))
            {
                SetActiveCorpse(bird, corpse);
            }
        }

        if (enemy is Fatso fatso)
        {
            if (GetObjectCorpse(out corpse, corpsesFatso))
            {
                SetActiveCorpse(fatso, corpse);
            }
        }
    }

    private void SetActiveCorpse(Enemy enemy, GameObject corpse)
    {
        corpse.gameObject.SetActive(true);
        corpse.transform.position = enemy.transform.position;
    }

    private void TryActivateWave(int maxScore)
    {
        if (_score >= maxScore)
        {
            _score = 0;
            StartCoroutine(SpawningEnemy(_poolsFatso));
        }
    }


    private void Start()
    {
      //  Initialize(_birdPrefab, _prafabsCorpseBird, _poolsBird, _poolCorpsesBird);
      //  Initialize(_fatsoPrefab, _prefabsCorpseFatso, _poolsFatso, _poolCorpsesFatso);

        StartCoroutine(SpawningEnemy(_poolsBird));
    }



    private IEnumerator SpawningEnemy(List<Enemy> listEnemy)
    {
        while (true)
        {
            if (TryGetObject(out Enemy enemy, listEnemy))
            {
                Vector3 ramdomSpawn = new Vector3(Random.Range(-18f, 18f), Random.Range(-9f, 9f));
                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

                if (listEnemy == _poolsBird)
                {
                    SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);
                }
                else
                {
                    SetEnemy(enemy, ramdomSpawn);

                }

                yield return new WaitForSeconds(_secondsBetweenSpawn);
            }

            yield return null;
        }
    }
}
