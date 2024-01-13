using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinerState : State
{
    private void Start()
    {
        _animator.Play(_jump);
    }
}
