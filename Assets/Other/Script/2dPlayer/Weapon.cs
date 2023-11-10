using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Bullet Bullet;

    protected Player2d _player2d;

    public abstract void Shoot();

    public void Remove()
    {
        Destroy(gameObject);
    }
}
