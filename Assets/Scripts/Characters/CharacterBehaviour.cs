using NaughtyAttributes;
using System;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    [SerializeField, Expandable]private CharacterData _characterData;

    private void TakeDamage(long amount)
    {
        if(amount < 0)
        {
            throw new ArgumentException("Damage amount can't be negative");
        }
        _characterData.Health -= amount;
    }
}
