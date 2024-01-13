using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RunState : State
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
    }
}
