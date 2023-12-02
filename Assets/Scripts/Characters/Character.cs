using System;
using System.Collections;
using UnityEngine;

public class Character : Entity
{
    [SerializeField] long _maxHealth = 1;
    long _currentHealth;
    [SerializeField] HealthBar _healthBar;

    [SerializeField] float _attackSpeed = 1.0f;
    Coroutine _idleAttack;

    [SerializeField] protected Character _target;

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
    public bool IsAlive => CurrentHealth <= 0;
    

    //Events
    Action<long, long> OnHealthChange;


    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        ExtInit();
        StartIdleAttack();
    }

    void Init()
    {
        OnHealthChange += _healthBar.SetHealthFill;
        CurrentHealth = _maxHealth;
    }

    public virtual void ExtInit()
    {

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

        if(CurrentHealth <= 0)
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

    public void Attack(Character target, long damage)
    {
        if (!target.IsAlive) return;
 
        target.TakeDamage(damage);
    }

    void StartIdleAttack()
    {
        _idleAttack = StartCoroutine(IdleAttack());
    }

    IEnumerator IdleAttack()
    {
        while (true)
        {
            Attack(_target, _damage);
            yield return new WaitForSeconds(1f/_attackSpeed);
        }
    }

    void StopIdleAttack()
    {
        if (_idleAttack != null) StopCoroutine(_idleAttack);
    }
}
