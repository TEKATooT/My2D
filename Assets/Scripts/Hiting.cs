using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hiting : MonoBehaviour
{
    [SerializeField] private float _hitRange;
    [SerializeField] private float _hitPower;

    [SerializeField] private PlayerMove _player;

    private GameObject _target;

    private void OnEnable()
    {
        _player.Hited += GiveHit;
    }

    private void OnDisable()
    {
        _player.Hited -= GiveHit;
    }

    private void GiveHit()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right * _hitRange);

        //Debug.DrawRay(transform.position, transform.right * _hitRange, Color.red);

        //Debug.Log("GO");

        if (hit)
        {
            _target = hit.collider.GetComponent<GameObject>();

            _target.SetActive(false);

            //_target.TakeDamage(_hitPower);
        }
    }
}
