using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
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
        }
    }

    public void GiveDamage()
    {
        if (_health > _zeroHealth)
        {
            _health += _damage;
        }
    }
}