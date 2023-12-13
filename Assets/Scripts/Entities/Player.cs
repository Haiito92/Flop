using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character, IAttacker, IAttackable
{
    [SerializeField] long _clickDamage;

    public void ClickAttack()
    {
        Attack(_clickDamage);
    }
}
