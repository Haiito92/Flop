using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, IAttacker
{
    [SerializeField] long _damage;

    [SerializeField] float _attackSpeed = 1.0f;
    Coroutine _idleAttack;

    IAttackable _target;

    //Properties
    #region Properties
    public IAttackable Target {  get { return _target; } set { _target = value; } }
    #endregion

    public void Attack(long damage)
    {
        if (!_target.IsAlive) return;

        _target.TakeDamage(damage);
    }

    public void StartIdleAttack()
    {
        if(_idleAttack == null) _idleAttack = StartCoroutine(IdleAttack());
    }

    IEnumerator IdleAttack()
    {
        while (true)
        {
            if(_target != null) Attack(_damage);
            yield return new WaitForSeconds(_attackSpeed);
        }
    }

    protected void StopIdleAttack()
    {
        if (_idleAttack != null)
        {
            StopCoroutine(_idleAttack);
            _idleAttack = null;
        }
    }
}
