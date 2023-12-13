using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, IAttacker
{
    [SerializeField] long _damage;

    [SerializeField] float _attackSpeed = 1.0f;
    Coroutine _idleAttack;

    [SerializeField] IAttackable _target;

    private void Start()
    {
        StartIdleAttack();
    }

    public void Attack(long damage)
    {
        if (!_target.IsAlive) return;

        _target.TakeDamage(damage);
    }

    protected void StartIdleAttack()
    {
        _idleAttack = StartCoroutine(IdleAttack());
    }

    IEnumerator IdleAttack()
    {
        while (true)
        {
            Attack(_damage);
            yield return new WaitForSeconds(1f / _attackSpeed);
        }
    }

    protected void StopIdleAttack()
    {
        if (_idleAttack != null) StopCoroutine(_idleAttack);
    }
}
