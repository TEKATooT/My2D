using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Hiting : MonoBehaviour
{
    [SerializeField] private float _hitRange;
    [SerializeField] private int _hitPower;

    [SerializeField] private PlayerMove _player;
    [SerializeField] private Transform _gunPosition;

    private void OnEnable()
    {
        _player.Hited += GiveHit;
    }

    private void OnDisable()
    {
        _player.Hited -= GiveHit;
    }

    private void GiveHit()
    {
        RaycastHit2D hit = Physics2D.Raycast(_gunPosition.position, transform.right, _hitRange);

        if (hit)
        {
            if (hit.collider.TryGetComponent(out AbstractWarrior target))
            {
                target.TakeDamage(_hitPower);
            }
        }
    }
}
