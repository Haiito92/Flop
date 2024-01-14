using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttack : MonoBehaviour
{
    [SerializeField] protected long _damage;

    //Properties
    #region Properties
    public long Damage { get => _damage; set => _damage = value; }
    #endregion

    public void Attack(CharacterHealth target, long damage)
    {
        if (!target.IsAlive) return;

        target.TakeDamage(damage);
    }

    
}
