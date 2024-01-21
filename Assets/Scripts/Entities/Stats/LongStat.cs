using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LongStat : Stat
{
    [SerializeField] long _baseValue = 1;

    [SerializeField] List<long> _additiveModifiers = new List<long>();

    long _additiveValue;

    public long GetValue()
    {
        long finalValue = _baseValue;

        if (_multiplicativeModifiers.Count > 0) finalValue = (long)(finalValue * _multiplicativeValue);

        if (_additiveModifiers.Count > 0) finalValue += _additiveValue;

        return finalValue;
    }

    public void SetValue(long value)
    {
        _baseValue = value;
    }

    public void AugmentBaseValue(long value)
    {
        _baseValue += value;
    }

    void SetAdditiveValue()
    {
        _additiveValue = 0;

        foreach(long modifier in _additiveModifiers)
        {
            _additiveValue += modifier;
        }
    }

    public void AddAdditiveModifier(long modifier)
    {
        _additiveModifiers.Add(modifier);
        SetAdditiveValue();
    }

    public void RemoveAdditiveModifier(long modifier)
    {
        _additiveModifiers.Remove(modifier);
        SetAdditiveValue();
    }
}
