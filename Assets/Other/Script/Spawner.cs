using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _respawns;
    [SerializeField] private Ball _ball;

    private Transform[] _respawnsPoints;

    private float _respawnsTime = 5f;

    private int _minRandomPosition = 0;
    private int _maxRandomPosition;

    private void Start()
    {
        SpawnerReloader();

        StartCoroutine(RespawnsTime());
    }

    private void SpawnerReloader()
    {
        _respawnsPoints = new Transform[_respawns.childCount];

        for (int i = 0; i < _respawns.childCount; i++)
        {
            _respawnsPoints[i] = _respawns.GetChild(i);
        }

        _maxRandomPosition = _respawns.childCount;
    }

    private IEnumerator RespawnsTime()
    {
        var waitForSeconds = new WaitForSeconds(_respawnsTime);

        while (true)
        {
            int respawnPoint = Random.Range(_minRandomPosition, _maxRandomPosition);

            var newBall = Instantiate(_ball, _respawnsPoints[respawnPoint].position, Quaternion.identity);
            
            newBall.GetTarget(_target);

            yield return waitForSeconds;
        }

    }
}
