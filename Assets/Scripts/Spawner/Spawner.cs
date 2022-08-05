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
    [SerializeField] private List<GameObject> _corpsesBird;
    [SerializeField] private List<GameObject> _corpsesFatso;

    private List<Enemy> _poolsBird = new List<Enemy>();
    private List<Enemy> _poolsFatso = new List<Enemy>();
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
        SetCorpse(enemy, _corpsesBird, _corpsesFatso);
    }

    public void SetCorpse(Enemy enemy, List<GameObject> corpsesBird, List<GameObject> corpsesFatso)
    {
        if (enemy = enemy.gameObject.GetComponent<Bird>())
        {
            if (TryGetObjectCorpse(out GameObject corpseBird, corpsesBird))
            {
                corpseBird.gameObject.SetActive(true);
                corpseBird.transform.position = enemy.transform.position;
            }
            
        }
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
        Initialize(_birdPrefab, _corpsesBird, _poolsBird);
        Initialize(_fatsoPrefab, _corpsesFatso, _poolsFatso);

        StartCoroutine(SpawningEnemy(_poolsBird));
        //  StartCoroutine(SpawningEnemy(_poolsFatso));
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
