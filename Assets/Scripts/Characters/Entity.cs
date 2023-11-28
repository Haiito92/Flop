using System;
using UnityEngine;

public class Entity : MonoBehaviour
{
    EntityStats _stats;

    private void Awake()
    {
        _stats.CurrentHealth = _stats.MaxHeath;
    }

    public void TakeDamage(long damage)
    {
        if (damage < 0) throw new ArgumentException("Damage can't be négative");
        _stats.CurrentHealth = (long)Mathf.Clamp(_stats.CurrentHealth - damage, 0, _stats.MaxHeath);
    }
}
