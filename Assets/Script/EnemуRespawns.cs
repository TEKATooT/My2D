using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(GameObject))]

public class EnemуRespawns : MonoBehaviour
{
    [SerializeField] private Transform _respawns;
    [SerializeField] private Transform _destinationPoint;
    [SerializeField] private GameObject _enemy;

    private Transform[] _respawnsPoints;
    private GameObject _newEnemy;

    private float _respawnsTime = 2f;
    private float _enemySpeed = 0.1f;

    private int _minRandomPosition = 0;
    private int _maxRandomPosition;

    void Start()
    {
        _respawnsPoints = new Transform[_respawns.childCount];

        for (int i = 0; i < _respawns.childCount; i++)
        {
            _respawnsPoints[i] = _respawns.GetChild(i);
        }

        _maxRandomPosition = _respawns.childCount;

        StartCoroutine(RespawnsTime());
    }

    void Update()
    {
        _newEnemy.transform.position = Vector2.MoveTowards(_newEnemy.transform.position, _destinationPoint.transform.position, _enemySpeed);
    }

    private IEnumerator RespawnsTime()
    {
        var waitForSeconds = new WaitForSeconds(_respawnsTime);

        while (true)
        {
            int respawnPoint = Random.Range(_minRandomPosition, _maxRandomPosition);

            _newEnemy = Instantiate(_enemy, _respawnsPoints[respawnPoint].position, Quaternion.identity);

            yield return waitForSeconds;
        }
    }
}
