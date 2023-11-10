using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiting : MonoBehaviour
{
    [SerializeField] private float _hitRange;

    private void TakeHit()
    {

    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right * _hitRange);
        
        Debug.DrawRay(transform.position, transform.right * _hitRange, Color.red);

        if (hit)
        {
            
        }
    }
}
