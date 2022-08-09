using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private float _currentScore;
    [SerializeField] private float _totalScore;
    [SerializeField] ProgressBar progressBar;
    public float FirstWave { get; private set; } = 300;

    public float TotalScore => _totalScore;
    public void GetScore(Enemy enemy)
    {
        _currentScore += enemy.StartingHealth;
        _totalScore += enemy.StartingHealth;
        progressBar.OnProgressChanged(_currentScore);
    }

    public void ResetCurrentStore()
    {
        _currentScore = 0;
        progressBar.OnProgressChanged(_currentScore);
    }
}
