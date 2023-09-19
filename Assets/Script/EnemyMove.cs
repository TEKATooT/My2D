using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private int patrolLength;
    [SerializeField] private int patrolTime;

    private void Start()
    {
        float _startPosition = transform.position.x;

        _startPosition += patrolLength;

        transform.DOLocalMoveX(_startPosition, patrolTime, false).SetLoops(-1, LoopType.Yoyo);
    }
}
