using NaughtyAttributes;
using System;
using UnityEngine;

public class HeroBehaviour : MonoBehaviour
{
    [SerializeField, Expandable] private HeroData _heroData;

    private void Awake()
    {
        GameManager.onClickDamage += TakeDamage;
        GameManager.onPlayerDamage += TakeDamage;
    }

    public void TakeDamage(long amount)
    {
        _heroData.Health -= amount;
        Debug.Log(_heroData.Health);

        if(_heroData.Health <= 0 )
        {
            Die();
        }
    }

    private void Die()
    {
        Reset();
    }

    private void Reset()
    {
        _heroData.Health = _heroData.MaxHealth;
    }
}
