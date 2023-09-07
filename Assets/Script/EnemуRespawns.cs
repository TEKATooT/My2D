using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(BoxCollider2D))]

public class EnemуRespawns : MonoBehaviour
{
    [SerializeField] private Transform _respawns;
    [SerializeField] private Transform _destinationPoint;
    [SerializeField] private GameObject _ball;

    private Transform[] _respawnsPoints;
    private GameObject _newBall;

    private float _respawnsTime = 2f;
    private float _ballSpeed = 0.1f;

    private int _minRandomPosition = 0;
    private int _maxRandomPosition;

    private void Start()
    {
        _respawnsPoints = new Transform[_respawns.childCount];

        for (int i = 0; i < _respawns.childCount; i++)
        {
            _respawnsPoints[i] = _respawns.GetChild(i);
        }

        _maxRandomPosition = _respawns.childCount;

        StartCoroutine(RespawnsTime());
    }

    private void Update()
    {
        _newBall.transform.position = Vector2.MoveTowards(_newBall.transform.position, _destinationPoint.transform.position, _ballSpeed);
    }

    private IEnumerator RespawnsTime()
    {
        var waitForSeconds = new WaitForSeconds(_respawnsTime);

        while (true)
        {
            int respawnPoint = Random.Range(_minRandomPosition, _maxRandomPosition);

            _newBall = Instantiate(_ball, _respawnsPoints[respawnPoint].position, Quaternion.identity);

            yield return waitForSeconds;
        }
    }
}
