using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Player _target;

    public Player Target => _target;

    public void SetTarget(Player target)
    {
        _target = target;
    }
}
