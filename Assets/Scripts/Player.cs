using System.Collections;
using UnityEngine;

public class Player : AbstractWarrior
{
    [SerializeField] private Transform _frontPosition;
    [SerializeField] private int _timeForSteal;
    [SerializeField] private float _skillRange;
    [SerializeField] private float _steelValue;
    [SerializeField] private float _liveStealcooldown = 10;

    [SerializeField] private AbstractWarrior _target;

    private float _cooldown = 0;
    private bool _isReady = true;

    private void Update()
    {
        SkillLiveSteal();
    }

    private void SkillLiveSteal()
    {
        if (Input.GetKeyDown(KeyCode.F) && _isReady == true)
        {
            RaycastHit2D target = Physics2D.Raycast(_frontPosition.position, transform.right, _skillRange);

            if (target)
            {
                if (_target.gameObject == target.collider.gameObject)
                {
                    StartCoroutine(LiveSteal(this, _target, _steelValue, _timeForSteal));

                    _cooldown = _liveStealcooldown;
                    _isReady = false;

                    StartCoroutine(CooldownTimer());
                }
            }
        }
    }

    private IEnumerator CooldownTimer()
    {
        var waitForSecond = new WaitForSeconds(_liveStealcooldown);

        yield return waitForSecond;

        _isReady = true;
    }
}