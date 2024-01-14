using UnityEngine;
using UnityEngine.Events;

public class Player : AbstractWarrior
{
    [SerializeField] private UnityEvent _upSlider;
    [SerializeField] private UnityEvent _downSlider;

    protected float _defaultHealth = 100;
    protected float _heal = .1f;
    protected float _damage = .1f;

    public void GiveHeal()
    {
        if (_health < _defaultHealth)
        {
            _health += _heal;

            _upSlider?.Invoke();

            if (_health > _defaultHealth)
            {
                _health = _defaultHealth;
            }
        }
    }

    public void GiveDamage()
    {
        if (_health >= _zeroHealth)
        {
            _health -= _damage;

            _downSlider?.Invoke();

            if (_health < _zeroHealth)
            {
                _health = _zeroHealth;
            }
        }
    }
}