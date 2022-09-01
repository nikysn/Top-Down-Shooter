using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : Bar
{
    [SerializeField] private Player _player;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private IEnumerator ChangeHealth(float currentHealth)
    {
        while (Slider.value != currentHealth)
        {
            Slider.value = Mathf.MoveTowards(Slider.value, currentHealth, _delta );
            yield return null;
        }
    }

    private void OnHealthChanged(float currentHealth)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ChangeHealth(currentHealth));
    }
}
