using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] Stat _maxHealth;
    long _currentHealth;

    [SerializeField] IdleBrain _characterAttack;

    private void Reset()
    {
        _characterAttack = GetComponent<IdleBrain>();
    }

    //Events
    public event Action<long, long> OnHealthChange;
    public event Action OnStartDeath;
    public event Action OnEndDeath;

    //Properties
    public long CurrentHealth
    {
        get => _currentHealth;
        set
        {
            _currentHealth = value;
            OnHealthChange?.Invoke(_currentHealth, (long)_maxHealth.GetValue());
        }
    }
    public bool IsAlive { get { return CurrentHealth > 0; } set { } }

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        OnHealthChange?.Invoke(_currentHealth, (long)_maxHealth.GetValue());
    }

    void Init()
    {
        CurrentHealth = (long)_maxHealth.GetValue();
    }

    public void Heal(long heal)
    {
        if (heal < 0) throw new ArgumentException("Heal value must be superior or equal to 0");
        CurrentHealth = (long)Mathf.Clamp(_currentHealth + heal, 0, (long)_maxHealth.GetValue());
    }

    public void TakeDamage(long damage)
    {
        if (damage < 0) throw new ArgumentException("Damage value must be superior or equal to 0");
        CurrentHealth = (long)Mathf.Clamp(_currentHealth - damage, 0, (long)_maxHealth.GetValue());

        if (CurrentHealth <= 0)
        {
            _characterAttack.StopAttackRoutine();
            OnStartDeath?.Invoke();
        }
    }
    public virtual void Die()
    {
        OnEndDeath?.Invoke();
        Destroy(GetComponentInParent<Transform>().gameObject);
    }


    public virtual void ResetCharacter()
    {
        CurrentHealth = (long)_maxHealth.GetValue();
        _characterAttack.StartAttackRoutine();
    }
}
