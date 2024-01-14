using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerBrain : BasicBrain
{
    //Fields
    [SerializeField] SpecialAttack _specialAttack;

    [SerializeField] float _maxSpecialResource;
    float _specialResource = 0.0f;
    [SerializeField] float _specialResourceAdded;

    private void Awake()
    {
        _specialResource = 0.0f;
    }

    private void Start()
    {
        StartAttackRoutine();
    }

    protected override IEnumerator AttackRoutine()
    {
        while (true)
        {
            if(_target == null)
            {
                yield return null;
                continue;
            }
            if (_specialResource >= _maxSpecialResource)
            {
                _specialAttack.DoSpecialAttack(_target);
                _specialResource = 0.0f;
            }
            else
            {
                _basicAttack.Attack(_target, _basicAttack.Damage);
                _specialResource = Mathf.Clamp(_specialResource + _specialResourceAdded, 0.0f, _maxSpecialResource);
            }
            yield return new WaitForSeconds(_attackSpeed);
        }
    }

    [Button]
    public override void FindAttacks()
    {
        base.FindAttacks();
        _specialAttack = _actions.GetComponent<SpecialAttack>();
    }
}
