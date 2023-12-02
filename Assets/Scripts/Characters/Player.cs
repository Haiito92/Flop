using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Character
{
    [SerializeField] long _clickDamage;

    public void ClickAttack()
    {
        Attack(_target, _clickDamage);
    }
}
