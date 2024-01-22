using System.Collections;
using UnityEngine;

public class Player : AbstractWarrior
{
    [SerializeField] private Transform _frontPosition;
    [SerializeField] private int _timeForSteal;
    [SerializeField] private float _skillRange;
    [SerializeField] private float _steelValue;
    [SerializeField] private float _liveStealcooldown = 10;

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
            RaycastHit2D hit = Physics2D.Raycast(_frontPosition.position, transform.right, _skillRange);

            if (hit)
            {
                if (hit.collider.TryGetComponent(out AbstractWarrior target))
                {
                    StartCoroutine(LiveSteal(this, target, _steelValue, _timeForSteal));

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