using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractProjectile : MonoBehaviour
{
    private Transform _target;

    [SerializeField] private float _speed;

    private void Update()
    {
        transform.position = Vector2.MoveTowards
            (transform.position, _target.position, _speed * Time.deltaTime);
    }

    public virtual void GetTarget(Transform target)
    {
        _target = target;
    }
}
