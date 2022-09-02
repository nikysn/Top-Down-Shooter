using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Spawner))]
[RequireComponent(typeof(Score))]
public class WaveControl : MonoBehaviour
{
    [field: SerializeField] public EnemyPool _birdPool { get; private set; }
    [SerializeField] private EnemyPool _fatsoPool;
    [SerializeField] private EnemyPool _moosePool;

    private List<EnemyPool> _enemyPools = new List<EnemyPool>();
    private Spawner _spawnerAdam;
    private Score _score;
    private List<float> _waves;
    private int _currentWave = 0;

    public event UnityAction NextWave;

    private void Start()
    {
        _waves = new List<float> { 300 };
        _enemyPools.Add(_fatsoPool);
        _enemyPools.Add(_moosePool);
    }
    private void Awake()
    {
        _spawnerAdam = GetComponent<Spawner>();
        _score = GetComponent<Score>();
    }

    public void OnNextWave(int index)
    {
        if (index < _enemyPools.Count)
        {
            StartCoroutine(_spawnerAdam.SpawnCoroutine(_enemyPools[index]));
        }
    }

    public void TryGetNewWave()
    {
        if (_score.CurrentScore >= _waves[_currentWave])
        {
            _birdPool.AddEnemy();
            _fatsoPool.AddEnemy();
            _moosePool.AddEnemy();
            OnNextWave(_currentWave);
            NextWave?.Invoke();
            _score.IncreaseCurrentScore(_waves[_currentWave]);
            AddNewWave();
            _currentWave++;
        }
    }

    public float NewCurrentScore()
    {
        return _waves[_currentWave];
    }

    private void AddNewWave()
    {
        int numberScore = 400;
        _waves.Add(numberScore);
    }
}
