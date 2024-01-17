using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractWarrior : MonoBehaviour
{
    [SerializeField] protected float _health;

    [SerializeField] private BarRenderer _barRenderer;

    private float _startHealth;
    private float _zeroHealth = 0;

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

    public void LiveSteal(Player player, Monster monster, float steelValue)
    {
        player._health = Mathf.MoveTowards(player._health, _startHealth, steelValue);

        monster._health = Mathf.MoveTowards(monster._health, _zeroHealth, steelValue);
    }
}
