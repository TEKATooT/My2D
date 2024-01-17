using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractWarrior : MonoBehaviour
{
    [SerializeField] protected int _health;

    [SerializeField] private BarRenderer _barRenderer;

    private int _startHealth;
    private int _zeroHealth = 0;

    private void Start()
    {
        _startHealth = _health;

        _barRenderer.Draw(_startHealth, _health);
    }

    public void TakeHeal(int heal)
    {
        if (_health < _startHealth)
        {
            _health += heal;

            if (_health > _startHealth)
            {
                _health = _startHealth;
            }

            _barRenderer.Draw(_startHealth, _health);
        }
    }

    public void TakeDamage(int damage)
    {
        if (_health > _zeroHealth)
        {
            _health -= damage;

            if (_health < _zeroHealth)
            {
                _health = _zeroHealth;
            }

            _barRenderer.Draw(_startHealth, _health);
        }
    }
}
