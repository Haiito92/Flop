using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttack : MonoBehaviour
{
    [SerializeField] protected long _damage;

    [SerializeField] protected CharacterHealth _target;

    //Properties
    #region Properties
    #endregion


    public void SetTarget(CharacterHealth target)
    {
        _target = target;
    }

    public void Attack(long damage)
    {
        if (!_target.IsAlive) return;

        _target.TakeDamage(damage);
    }

    
}
