using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTransition : Transition
{
    private float _range = 1.35f;

    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.transform.position) < _range)
        {
            NeedTransit = true;
        }
    }
}
