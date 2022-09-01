using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : Bar
{
    [SerializeField] private Score _score;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _score.OnScoreChange += SetProgress;
    }

    private void OnDisable()
    {
        _score.OnScoreChange -= SetProgress;
    }

    public void OnProgressChanged(float currentScore)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ChangeProgress(currentScore));
    }

    public void IncreaseBar(float number)
    {
        Slider.maxValue = number;
    }

    private IEnumerator ChangeProgress(float score)
    {
        while (Slider.value != score)
        {
            Slider.value = Mathf.MoveTowards(Slider.value, score, _delta * Time.deltaTime);
            yield return null;
        }
    }

    private void SetProgress(float maxValue, float value)
    {
        float score = value / maxValue;
        OnProgressChanged(score);
    }
}
