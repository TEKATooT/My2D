using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractWarrior : MonoBehaviour
{
    [SerializeField] protected float _health;

    [SerializeField] private BarRenderer _barRenderer;

    private float _defaultHealth;
    private int _zeroHealth = 0;

    private void Start()
    {
        _defaultHealth = _health;
    }

    public void TakeHeal(int heal)
    {
        if (_health < _defaultHealth)
        {
            _health += heal;

            _barRenderer.SliderUp(heal);

            if (_health > _defaultHealth)
            {
                _health = _defaultHealth;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (_health > _zeroHealth)
        {
            _health -= damage;

            _barRenderer.SliderDown(damage);

            if (_health < _zeroHealth)
            {
                _health = _zeroHealth;
            }
        }
    }
}
