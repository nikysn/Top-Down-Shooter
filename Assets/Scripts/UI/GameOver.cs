using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class GameOver : MonoBehaviour
{
    private TMP_Text _textScore;
    [SerializeField] private Player _player;

    private void Awake()
    {
        _textScore = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        _textScore.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _player.Die += OnText;
    }

    public void OnText()
    {
        _textScore.gameObject.SetActive(true);
    }
}
