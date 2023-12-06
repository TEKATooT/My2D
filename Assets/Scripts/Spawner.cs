using System.Collections;
using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _respawns;
    [SerializeField] private Ball _ball;
    [SerializeField] private Ņannonball _projectile;
    [SerializeField] private Player _player;
    [SerializeField] private float _respawnsTime;

    private Transform[] _respawnsPoints;

    private int _minRandomPosition = 0;
    private int _maxRandomPosition;
    private int _half = 2;
    private int _halfOfSpawners;

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

        _halfOfSpawners = _maxRandomPosition / _half;
    }

    private IEnumerator RespawnsTime()
    {
        var waitForSeconds = new WaitForSeconds(_respawnsTime);

        while (true)
        {
            int respawnPoint = Random.Range(_minRandomPosition, _maxRandomPosition);

            if (respawnPoint > _halfOfSpawners)
            {
                var newAmmunition = Instantiate(_ball, _respawnsPoints[respawnPoint].position, Quaternion.identity);

                newAmmunition.GetTarget(_target);
            }
            else
            {
                var newAmmunition = Instantiate(_projectile, _respawnsPoints[respawnPoint].position, Quaternion.identity);

                newAmmunition.GetTarget(_player.transform);
            }

            yield return waitForSeconds;
        }
    }
}
