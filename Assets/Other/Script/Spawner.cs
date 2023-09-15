using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Transform _respawns;

    private Transform[] _respawnsPoints;

    private float _respawnsTime = 2f;

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

    private IEnumerator RespawnsTime()
    {
        var waitForSeconds = new WaitForSeconds(_respawnsTime);

        while (true)
        {
            int respawnPoint = Random.Range(_minRandomPosition, _maxRandomPosition);

            Instantiate(_ball, _respawnsPoints[respawnPoint].position, Quaternion.identity);

            yield return waitForSeconds;
        }
    }
}
