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

    //Events
    Action<long, long> OnHealthChange;


    private void Awake()
    {
        _currentHealth = _maxHealth;
        OnHealthChange += _healthBar.SetHealthFill;
    }

    private void Start()
    {
        StartIdleAttack();
    }

    public void Heal(long heal)
    {
        if (heal < 0) throw new ArgumentException("Heal value must be superior or equal to 0");
        _currentHealth = (long)Mathf.Clamp(_currentHealth + heal, 0, _maxHealth);
        OnHealthChange.Invoke(_currentHealth, _maxHealth);
    }

    public void TakeDamage(long damage)
    {
        if (damage < 0) throw new ArgumentException("Damage value must be superior or equal to 0");
        _currentHealth = (long)Mathf.Clamp(_currentHealth - damage, 0, _maxHealth);
        OnHealthChange.Invoke(_currentHealth, _maxHealth);

        if(_currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        StopIdleAttack();
    }

    public void Attack(Character target, long damage)
    {
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
