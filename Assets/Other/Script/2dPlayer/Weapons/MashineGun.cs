using UnityEngine;

public class MashineGun : Weapon
{
    [SerializeField] private Transform _shootPoint;

    public override void Shoot()
    {
        Instantiate(Bullet, _shootPoint.position, Quaternion.identity);
    }
}
