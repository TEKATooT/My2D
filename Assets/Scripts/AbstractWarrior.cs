using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class AbstractWarrior : MonoBehaviour
{
    [SerializeField] protected float _health;

    private float _startHealth;
    private float _zeroHealth = 0;

    public event UnityAction<float> HealthCheched;
    public float Health => _health;

    private void Start()
    {
        _startHealth = _health;

        HealthCheched?.Invoke(_health);
    }

    public void TakeHeal(float heal)
    {
        if (_health < _startHealth)
        {
            _health += heal;

            if (_health > _startHealth)
            {
                _health = _startHealth;
            }

            HealthCheched?.Invoke(_health);
        }
    }

    public void TakeDamage(float damage)
    {
        if (_health > _zeroHealth)
        {
            _health -= damage;

            if (_health < _zeroHealth)
            {
                _health = _zeroHealth;
            }

            HealthCheched?.Invoke(_health);
        }
    }

    public IEnumerator LiveSteal(Player player, AbstractWarrior target, float steelValue, int timeForSteal)
    {
        var waitForOneSecond = new WaitForSeconds(1);

        for (int i = 0; i < timeForSteal; i++)
        {
            player.TakeHeal(steelValue);

            target.TakeDamage(steelValue);

            yield return waitForOneSecond;
        }
    }
}
