using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable
{
    public bool IsAlive { get; set; }

    public abstract void TakeDamage(long damage);
}
