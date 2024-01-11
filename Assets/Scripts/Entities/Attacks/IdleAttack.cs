using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class IdleAttack : BaseAttack
{
    [SerializeField] float _attackSpeed = 1.0f;
    Coroutine _idleAttack;

    private void Start()
    {
        StartIdleAttack();
    }

    public void StartIdleAttack()
    {
        if (_idleAttack == null) _idleAttack = StartCoroutine(IdleAttackCoroutine());
    }

    IEnumerator IdleAttackCoroutine()
    {
        while (true)
        {
            if (_target != null) Attack(_damage);
            yield return new WaitForSeconds(_attackSpeed);
        }
    }

    public void StopIdleAttack()
    {
        if (_idleAttack != null)
        {
            StopCoroutine(_idleAttack);
            _idleAttack = null;
        }
    }
}
