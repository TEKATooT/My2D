using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Player2d _player2d;

    public void SellMahineGun()
    {
        for (int i = 0; i < _weapons.Count; i++)
        {
            if (_weapons[i].name == "MashineGun")
            {
                var newWeapon = Instantiate(_weapons[i], _player2d.GunTransform.position, Quaternion.identity);

                _player2d.TakeWeapon(newWeapon);
            }
        }
    }
}
