using System.Collections;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _respawnsItem;
    [SerializeField] private Transform _respawns;

    [SerializeField] private int _respawnsTime;

    private Transform[] _respawnsPoints;

    private int _maxPosition;
    private int _minPosition = 0;
    private int _randomPosition;

    private void Start()
    {
        ReloadSpawner();

        StartCoroutine(RandomSpawner());
    }

    private void ReloadSpawner()
    {
        _respawnsPoints = new Transform[_respawns.childCount];

        for (int i = 0; i < _respawns.childCount; i++)
        {
            _respawnsPoints[i] = _respawns.GetChild(i);
        }

        _maxPosition = _respawns.childCount;
    }

    private IEnumerator RandomSpawner()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_respawnsTime);

        while (true)
        {
            _randomPosition = Random.Range(_minPosition, _maxPosition);

            Instantiate(_respawnsItem, _respawnsPoints[_randomPosition].position, Quaternion.identity);

            yield return waitForSeconds;
        }
    }

    private void AllSpawned()
    {
        foreach (var points in _respawnsPoints)
        {
            Instantiate(_respawnsItem, points.position, Quaternion.identity);
        }
    }
}
