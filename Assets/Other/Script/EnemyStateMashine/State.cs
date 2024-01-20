using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class State : MonoBehaviour
{
    [SerializeField] private Transition[] _transitions;

    protected Player Target { get; set; }

    protected Animator _animator;

    protected int _hit = Animator.StringToHash("MonsterAttack");
    protected int _run = Animator.StringToHash("MonsterRun");
    protected int _walk = Animator.StringToHash("MonsterWalk");
    protected int _jump = Animator.StringToHash("MonsterJump");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Entry(Player target)
    {
        if (enabled == false)
        {
            Target = target;
            enabled = true;

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(Target);
            }
        }
    }

    public void Exit()
    {
        if (enabled == true)
        {
            foreach (var transition in _transitions)
            {
                transition.enabled = false;
            }

            enabled = false;
        }
    }

    public State GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if(transition.NeedTransit) 
            {
                return transition.TargetState;
            }
        }

        return null;
    }
}
