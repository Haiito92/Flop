using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAttack : BaseAttack
{
    public void OnClickAttack(CharacterHealth target)
    {
        Attack(target, _damage);
    }
}
