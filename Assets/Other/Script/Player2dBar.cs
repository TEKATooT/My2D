using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2dBar : MonoBehaviour
{
    [SerializeField] private Player2d _trackablePlayer;
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _trackablePlayer.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _trackablePlayer.HealthChanged -= OnHealthChanged;

        _slider.maxValue = _trackablePlayer.Health;
    }

    private void OnHealthChanged(int health)
    {
        _slider.value = health;
    }
}
