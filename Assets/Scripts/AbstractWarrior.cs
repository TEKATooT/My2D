using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractWarrior : MonoBehaviour
{
    protected float _health = 100;

    protected float _zeroHealth = 0;

    public void TakeDamage(int damage)
    {
        if (_health >= _zeroHealth)
        {
            _health -= damage;

            if (_health < _zeroHealth)
            {
                _health = _zeroHealth;
            }
        }
    }
}
