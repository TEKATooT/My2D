using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Player2d _target;

    public Player2d Target => _target;

    public void SetTarget(Player2d target)
    {
        _target = target;
    }
}
