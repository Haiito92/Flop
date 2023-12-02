using System;
using UnityEngine;

public class Character : Entity
{
    [SerializeField] long _maxHealth = 1;
    long _currentHealth;

    [SerializeField] protected Character _target;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }


    public void Heal(long heal)
    {
        if (heal < 0) throw new ArgumentException("Heal value must be superior or equal to 0");
        _currentHealth = (long)Mathf.Clamp(_currentHealth + heal, 0, _maxHealth);
    }

    public void TakeDamage(long damage)
    {
        if (damage < 0) throw new ArgumentException("Damage value must be superior or equal to 0");
        _currentHealth = (long)Mathf.Clamp(_currentHealth - damage, 0, _maxHealth);
    }
    public void Attack(Character target, long damage)
    {
        target.TakeDamage(damage);
    }
}
