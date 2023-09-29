using NaughtyAttributes;
using System;
using UnityEngine;

public class HeroBehaviour : MonoBehaviour
{
    [SerializeField, Expandable] private TestData _heroData;

    private void Awake()
    {
        PlayerController.OnClickCallBack += TakeDamage;
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
