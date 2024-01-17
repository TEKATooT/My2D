using System.Numerics;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class Player : AbstractWarrior
{
    [SerializeField] private Transform _frontPosition;
    [SerializeField] private float _skillRange;
    [SerializeField] private float _steelValue;

    [SerializeField] private Player _self;
    [SerializeField] private Monster _target;



    private void Update()
    {
        SkillLiveSteal();
    }

    private void SkillLiveSteal()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            RaycastHit2D target = Physics2D.Raycast(_frontPosition.position, transform.right, _skillRange);

            if (target)
            {
                if (_target.gameObject == target.collider.gameObject)
                {
                    LiveSteal(_self, _target, _steelValue);
                }
            }
        }
    }
}