using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    [SerializeField] private Transform _shootPoint;

    public override void Shoot()
    {
        Instantiate(Bullet, _shootPoint.position, Quaternion.identity);
    }
}
