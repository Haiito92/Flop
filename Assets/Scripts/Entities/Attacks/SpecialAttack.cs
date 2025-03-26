using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack : BaseAttack
{
    public void DoSpecialAttack(CharacterHealth target)
    {
        Attack(target, (long)_damage.GetValue());
    }
}
