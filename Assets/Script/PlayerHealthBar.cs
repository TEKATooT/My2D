using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _reactionSlider;

    private float _health = 1;
    private float _startHealth = 1;
    private float _heal = .1f;
    private float _damage = -.1f;
    private float _zeroHealth = 0;

    public void GiveHeal()
    {
        if (_health < _startHealth)
        {
        _health += _heal;
        _slider.DOValue(_health, _reactionSlider);
        }
    }

    public void GiveDamage()
    {
        if (_health > _zeroHealth)
        {
            _health += _damage;
            _slider.DOValue(_health, _reactionSlider);
        }
    }
}
