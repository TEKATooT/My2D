using UnityEngine;

public class Hiting : MonoBehaviour
{
    [SerializeField] private float _hitRange;
    [SerializeField] private int _hitPower;

    [SerializeField] private PlayerMove _player;

    [SerializeField] private Transform _gunPosition;

    [SerializeField] private Player2d _player2;

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

       // Debug.DrawRay(_gunPosition.position, transform.right, Color.red);

        if (hit)
        {
            if (_player2.gameObject == hit.collider.gameObject)
            {
                //  Debug.Log("HIT!");

                _player2.TakeDamage(_hitPower);
            }
        }
    }
}
