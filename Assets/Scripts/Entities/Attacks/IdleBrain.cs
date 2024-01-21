using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class IdleBrain : CharacterBrain
{
    private void Start()
    {
        StartAttackRoutine();
    }

    protected override IEnumerator AttackRoutine()
    {
        while (true)
        {
            if (_target != null) _basicAttack.Attack(_target, (long)_basicAttack.Damage.GetValue());
            yield return new WaitForSeconds(_attackSpeed.GetValue());
        }
    }
}
