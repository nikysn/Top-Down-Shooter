using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class TotalScore : MonoBehaviour
{
    [SerializeField] private Score _score;

    private TMP_Text _textScore;

    private void Awake()
    {
        _textScore = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _score.GetTotalScore += GetScore;
    }

    public void GetScore(float score)
    {
        _textScore.text = score.ToString();
    }
}
