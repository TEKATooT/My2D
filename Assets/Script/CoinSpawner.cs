using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private Transform _respawns;

    private Transform[] _respawnsPoints;

    private void Start()
    {
        _respawnsPoints = new Transform[_respawns.childCount];

        for (int i = 0; i < _respawns.childCount; i++)
        {
            _respawnsPoints[i] = _respawns.GetChild(i);
        }

        foreach (var points in _respawnsPoints)
        {
            Instantiate(_coin, points.position, Quaternion.identity);
        }
    }
}
