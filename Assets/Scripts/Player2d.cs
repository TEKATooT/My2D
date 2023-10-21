using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Player2d : MonoBehaviour
{
    [SerializeField] private Weapon _currentWeapon;
    //[SerializeField] private Transform _gunTransform;

    private Animator _animator;
    private int _shot = Animator.StringToHash("Shooting");

   // public Transform GunTransform => _gunTransform;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _currentWeapon != null)
        {
            _currentWeapon.Shoot();

            _animator.Play(_shot);
        }
    }
}
