using DG.Tweening;
using UnityEngine;

public class SeeTargetTransiton : Transition
{
    [SerializeField] private Transform _monsterFront;
    [SerializeField] private float _seeRange;

    private void Update()
    {
        if (TryGetTarget())
        {
            NeedTransit = true;
        }
    }

    public bool TryGetTarget()
    {
        RaycastHit2D see = Physics2D.Raycast(_monsterFront.position, transform.right, _seeRange);

        if (see)
        {
            if (Target.gameObject == see.collider.gameObject)
            {
                DOTween.KillAll();

                return true;
            }
        }

        return false;
    }
}
