using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackState : State
{
    [SerializeField] private float _hitRange;
    [SerializeField] private Transform _monsterFront;
    [SerializeField] private Player _target;
    [SerializeField] private int _hitPower;

    [SerializeField] private float _speedAttack = 2;
    private float _coolDown;

    private Animator _animator;

    private int _hit = Animator.StringToHash("MonsterAttack");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
 
    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(_monsterFront.position, transform.right, _hitRange);

        _coolDown -= Time.deltaTime;

        if (hit)
        {
            if (_coolDown <= 0 && _target.gameObject == hit.collider.gameObject)
            {
                _target.TakeDamage(_hitPower);

                _animator.Play(_hit);

                _coolDown = _speedAttack;
            }
        }
    }
}
