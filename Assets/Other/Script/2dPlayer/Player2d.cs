using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(ParticleSystemRenderer))]

public class Player2d : MonoBehaviour
{
    [SerializeField] private Weapon _currentWeapon;
    [SerializeField] private Transform _gunTransform;

    [SerializeField] private Transform _gunHand;

    [SerializeField] private int _health;

    private ParticleSystemRenderer _particleSystemRenderer;

    private Animator _animator;
    private int _shot = Animator.StringToHash("Shooting");

    public Transform GunTransform => _gunTransform;

    public UnityAction<int> HealthChanged;

    public int Health => _health;

    private void Awake()
    {
        _particleSystemRenderer = GetComponent<ParticleSystemRenderer>();

        _animator = GetComponent<Animator>();

        HealthChanged?.Invoke(_health);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && _currentWeapon != null)
        {
            _currentWeapon.Shoot();

            _animator.Play(_shot);
        }
    }

    public void TakeWeapon(Weapon weapon)
    {
        _currentWeapon.Remove();

        _currentWeapon = weapon;

        _currentWeapon.transform.SetParent(_gunHand);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        HealthChanged?.Invoke(_health);

        _particleSystemRenderer.enabled = true;
    }
}
