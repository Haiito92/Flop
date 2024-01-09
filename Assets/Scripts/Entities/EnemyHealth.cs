using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : CharacterHealth
{
    [SerializeField] long _goldDropped;
    [SerializeField] PlayerResources _playerResources;

    public override void Die()
    {
        _playerResources.AddGold(_goldDropped);

        FightManager.Instance.ToNextSegment();

        base.Die();
    }
}
