using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    long _golds;

    public event Action<long> OnGoldChanged;

    #region Properties
    public long Golds => _golds;
    #endregion

    public void AddGold(long amount)
    {
        _golds = (long)Mathf.Clamp(_golds + amount, 0, long.MaxValue);
        OnGoldChanged?.Invoke(_golds);
    }
}
