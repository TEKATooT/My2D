using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(SpriteRenderer))]

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private int patrolLength;
    [SerializeField] private int patrolTime;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        float _startPosition = transform.position.x;

        _startPosition += patrolLength;

        transform.DOLocalMoveX(_startPosition, patrolTime, false).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo).OnStepComplete(Flip);
    }

    private void Flip()
    {
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
    }
}
