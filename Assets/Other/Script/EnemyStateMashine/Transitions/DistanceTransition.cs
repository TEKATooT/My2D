using UnityEngine;

public class DistanceTransition : Transition
{
    [SerializeField] private float _range = 1.6f;

    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.transform.position) < _range)
        {
            NeedTransit = true;
        }
    }
}
