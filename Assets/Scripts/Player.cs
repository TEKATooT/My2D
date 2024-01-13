using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private UnityEvent _upSlider;
    [SerializeField] private UnityEvent _downSlider;

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

            _upSlider.Invoke();
        }
    }

    public void GiveDamage()
    {
        if (_health > _zeroHealth)
        {
            _health += _damage;

            _downSlider.Invoke();
        }
    }

    public void TakeDamage(int damage)
    {
    }
}