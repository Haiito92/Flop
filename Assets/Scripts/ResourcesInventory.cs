using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesInventory : MonoBehaviour
{
    //Fields
    long _gold;

    //Dev Events
    public event Action<long> OnGoldChanged;

    //Properties
    public long Gold => _gold;

    public void AddGold(long amount)
    {
        _gold = (long)Mathf.Clamp(_gold + amount, 0, long.MaxValue);
        OnGoldChanged?.Invoke(_gold);
    }
}
