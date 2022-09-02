using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(WaveControl))]
public class Score : MonoBehaviour
{
    private Money _money;
    private WaveControl _waveControl;

    public float CurrentScore { get; private set; }
    public float TotalScore { get; private set; }

    public event UnityAction<float, float> OnScoreChange;
    public event UnityAction<float> GetTotalScore;

    private void Start()
    {
        _waveControl = GetComponent<WaveControl>();
    }

    public void GetScore(Enemy enemy)
    {
        CurrentScore += enemy.StartingHealth;
        TotalScore += enemy.StartingHealth;
        _waveControl.TryGetNewWave();
        ChangeBar();
    }

    public void Init(Money money)
    {
        _money = money;
        _money.MoneyPicked += OnMoneyPicked;
    }

    private void OnMoneyPicked(float money)
    {
        CurrentScore += money;
        TotalScore += money;
        _waveControl.TryGetNewWave();
        ChangeBar();
    }

    public void IncreaseCurrentScore(float newScore)
    {
        CurrentScore %= newScore;
    }

    private void ChangeBar()
    {
        GetTotalScore?.Invoke(TotalScore);
        OnScoreChange?.Invoke(_waveControl.NewCurrentScore(), CurrentScore);
    }
}
