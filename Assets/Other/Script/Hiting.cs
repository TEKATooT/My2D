using UnityEngine;

public class Hiting : MonoBehaviour
{
    [SerializeField] private float _hitRange;
    [SerializeField] private int _hitPower;

    [SerializeField] private PlayerMove _player;

    [SerializeField] private Transform _gunPosition;

    [SerializeField] private AbstractWarrior _target;

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
            if (_target.gameObject == hit.collider.gameObject)
            {
                _target.TakeDamage(_hitPower);
            }
        }
    }
}
