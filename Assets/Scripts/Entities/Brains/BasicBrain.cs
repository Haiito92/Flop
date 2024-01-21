using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class BasicBrain : MonoBehaviour
{
    protected CharacterHealth _target;

    [SerializeField] protected BaseAttack _basicAttack;
    [SerializeField] protected FloatStat _attackSpeed;

    //Refs to components in same prefab
    [SerializeField] protected GameObject _actions;

    //Coroutines
    Coroutine _attackRoutine = null;

    //Events for devs
    public Action OnBasicAttack;


    public void SetTarget(CharacterHealth target)
    {
        _target = target;
    }

    public virtual void StartAttackRoutine()
    {
        if (_attackRoutine == null) _attackRoutine = StartCoroutine(AttackRoutine());
    }
    protected abstract IEnumerator AttackRoutine();
    public virtual void StopAttackRoutine()
    {
        if (_attackRoutine != null)
        {
            StopCoroutine(_attackRoutine);
            _attackRoutine = null;
        }
    }

    protected virtual void FindAttacks()
    {
        _basicAttack = _actions.GetComponent<BaseAttack>();
    }

    public void DoBasicAttack()
    {
        _basicAttack.Attack(_target, _basicAttack.Damage.GetValue());
    }

    [Button]
    public void FindAttack() => FindAttacks();
}
