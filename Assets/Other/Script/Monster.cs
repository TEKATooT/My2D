using UnityEngine;

public class Monster : AbstractWarrior
{
    public Player _target;

    public Player Target => _target;

    public void SetTarget(Player target)
    {
        _target = target;
    }
}
