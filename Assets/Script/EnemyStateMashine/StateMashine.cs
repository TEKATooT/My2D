using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StateMashine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private Player _target;
    private State _currentState;

    public State Current => _currentState;

    private void Start()
    {
        _target = GetComponent<Monster>().Target;
        ResetState(_firstState);
    }

    private void Update()
    {
        if (_currentState == null)
        {
            return;
        }

        var nextState = _currentState.GetNextState();

        if (nextState != null)
        {
            Transit(nextState);
        }
    }

    private void ResetState(State startState)
    {
        _currentState = startState;

        if (_currentState != null) 
        {
            _currentState.Enter(_target);
        }
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = nextState;

        if (_currentState != null)
        {
            _currentState.Enter(_target);
        }
    }
}
