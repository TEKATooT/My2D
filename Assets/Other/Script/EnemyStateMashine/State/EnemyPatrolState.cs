using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(SpriteRenderer))]

public class EnemyPatrolState : State
{
    [SerializeField] private int patrolLength;
    [SerializeField] private int patrolTime;

    private int _flipAngle = -180;

    private void Start()
    {
        Patrolling();
    }

    public void Patrolling()
    {
        float _startPosition = transform.position.x;

        _startPosition += patrolLength;

        transform.DOLocalMoveX(_startPosition, patrolTime, false).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo).OnStepComplete(Flip);
    }

    private void Flip()
    {
        transform.Rotate(0, _flipAngle, 0);
    }
}
