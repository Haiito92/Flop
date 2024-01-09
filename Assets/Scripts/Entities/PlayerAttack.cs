using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : CharacterAttack
{
    [SerializeField] long _clickDamage;
    public void ClickAttack()
    {
        Attack(_clickDamage);
    }
}
