using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
       // _spawner.HealthChanged += OnValueChanged;
       // Slider.value = 0;
    }

    private void OnDisable()
    {
        //_spawner.HealthChanged -= OnValueChanged;
    }

}
