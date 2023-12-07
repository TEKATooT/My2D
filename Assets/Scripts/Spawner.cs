using System.Collections;
using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _respawns;
    [SerializeField] private Ball _ball;
    [SerializeField] private Cannonball _projectile;
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
                ThrowShell(_ball, _target, respawnPoint);
            }
            else
            {
                ThrowShell(_projectile, _player.transform, respawnPoint);
            }

            yield return waitForSeconds;
        }
    }

    private void ThrowShell(AbstractProjectile shell, Transform target, int respawnPoint)
    {
        var newShell = Instantiate(shell, _respawnsPoints[respawnPoint].position, Quaternion.identity);

        newShell.GetTarget(target);
    }
}
