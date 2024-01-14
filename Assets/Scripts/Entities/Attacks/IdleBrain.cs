using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class IdleBrain : BasicBrain
{
    private void Start()
    {
        StartAttackRoutine();
    }

    protected override IEnumerator AttackRoutine()
    {
        while (true)
        {
            if (_target != null) _basicAttack.Attack(_target, _basicAttack.Damage);
            yield return new WaitForSeconds(_attackSpeed);
        }
    }
}
