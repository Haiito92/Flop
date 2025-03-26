using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : CharacterHealth
{
    public override void Die()
    {
        FightManager.Instance.ToNextSegment();

        base.Die();
    }
}
