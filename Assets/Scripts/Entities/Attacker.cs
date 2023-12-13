using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] long _damage;

    [SerializeField] float _attackSpeed = 1.0f;
    Coroutine _idleAttack;

    [SerializeField] Attackable _target;

    private void Start()
    {
        StartIdleAttack();
    }

    public void Attack(long damage)
    {
        if (!_target.IsAlive) return;

        _target.TakeDamage(damage);
    }

    void StartIdleAttack()
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

    void StopIdleAttack()
    {
        if (_idleAttack != null) StopCoroutine(_idleAttack);
    }
}
