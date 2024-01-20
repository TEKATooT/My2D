using UnityEngine;

public class Player : AbstractWarrior
{
    [SerializeField] private Transform _frontPosition;
    [SerializeField] private int _timeForSteal;
    [SerializeField] private float _skillRange;
    [SerializeField] private float _steelValue;
    [SerializeField] private float _liveStealcooldown = 10;

    [SerializeField] private Player _self;
    [SerializeField] private Monster _target;

    private float _cooldown = 0;

    private void Update()
    {
        SkillLiveSteal();

        _cooldown -= Time.deltaTime;
    }

    private void SkillLiveSteal()
    {
        if (Input.GetKeyDown(KeyCode.F) && _cooldown <= 0)
        {
            RaycastHit2D target = Physics2D.Raycast(_frontPosition.position, transform.right, _skillRange);

            if (target)
            {
                if (_target.gameObject == target.collider.gameObject)
                {
                     StartCoroutine(LiveSteal(_self, _target, _steelValue, _timeForSteal));

                    _cooldown = _liveStealcooldown;
                }
            }
        }
    }
}