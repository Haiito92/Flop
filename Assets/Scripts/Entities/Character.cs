using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Entity, IAttacker, IAttackable
{
    [SerializeField] long _maxHealth = 1;
    long _currentHealth;
    [SerializeField] HealthBar _healthBar;


    //Properties
    public long CurrentHealth
    {
        get => _currentHealth;
        set
        {
            _currentHealth = value;
            OnHealthChange?.Invoke(_currentHealth, _maxHealth);
        }
    }
    public bool IsAlive { get { return CurrentHealth >= 0; } set { } }

    //Events
    Action<long, long> OnHealthChange;


    private void Awake()
    {
        Init();
    }

    void Init()
    {
        OnHealthChange += _healthBar.SetHealthFill;
        CurrentHealth = _maxHealth;
    }

    public void Heal(long heal)
    {
        if (heal < 0) throw new ArgumentException("Heal value must be superior or equal to 0");
        CurrentHealth = (long)Mathf.Clamp(_currentHealth + heal, 0, _maxHealth);
    }

    public void TakeDamage(long damage)
    {
        if (damage < 0) throw new ArgumentException("Damage value must be superior or equal to 0");
        CurrentHealth = (long)Mathf.Clamp(_currentHealth - damage, 0, _maxHealth);

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        StopIdleAttack();
    }

    public virtual void ResetCharacter()
    {
        CurrentHealth = _maxHealth;
        StartIdleAttack();
    }


}
