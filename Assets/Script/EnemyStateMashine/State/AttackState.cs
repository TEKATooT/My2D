using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackState : State
{
    private Animator _animator;

    private int _hit = Animator.StringToHash("MonsterAttack");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
 
    private void Update()
    {
        _animator.Play(_hit);
    }
}
