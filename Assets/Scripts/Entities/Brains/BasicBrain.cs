using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class BasicBrain : MonoBehaviour
{
    protected CharacterHealth _target;

    [SerializeField] protected BaseAttack _basicAttack;
    [SerializeField] protected Stat _attackSpeed;

    //Refs to components in same prefab
    [SerializeField] protected GameObject _actions;

    //Coroutines
    Coroutine _attackRoutine;

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

    [Button]
    public void FindAttack() => FindAttacks();
}
