using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class BasicBrain : MonoBehaviour
{
    [SerializeField] protected CharacterHealth _target;

    [SerializeField] protected List<BaseAttack> _attackList = new List<BaseAttack>();
    [SerializeField] protected BaseAttack _basicAttack;
    [SerializeField] protected float _attackSpeed;

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

    [Button]
    public virtual void FindAttacks()
    {
        _attackList.Clear();
        _attackList = _actions.GetComponents<BaseAttack>().ToList();
        _basicAttack = _actions.GetComponent<BaseAttack>();
    }
}
