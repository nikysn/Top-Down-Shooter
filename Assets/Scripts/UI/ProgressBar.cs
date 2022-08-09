using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : Bar
{
    //[SerializeField] private Spawner _spawner;
    [SerializeField] private Score _score;
    private Coroutine _coroutine;
    [SerializeField] private float _currentProgress ;

    private void Awake()
    {
        Slider.maxValue = _score.FirstWave;
        _currentProgress = Slider.value;
        
    }

    private void OnEnable()
    {
      //  _spawner.OnEnemyDeath += OnProgressChanged;
        // Slider.value = 1;
    }

    private void OnDisable()
    {
        //_spawner.OnEnemyDeath -= OnProgressChanged;
    }

    private IEnumerator ChangeProgress(float score)
    {
        _currentProgress = score;

        while (Slider.value != score)
        {
            Slider.value = Mathf.MoveTowards(Slider.value, score, _delta);
            yield return null;
        }
    }

    public void OnProgressChanged(float currentScore)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ChangeProgress(currentScore));
    }
}
