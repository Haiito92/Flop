using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character, IAttacker, IAttackable
{
    public override void Die()
    {
        base.Die();

        GameManager.Instance.OnNextSegment?.Invoke();
    }
}
