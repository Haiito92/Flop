using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LongStat : Stat<long>
{
    public override long GetValue()
    {
        long finalValue = _baseValue;

        if (_multiplicativeModifiers.Count > 0) finalValue = (long)(finalValue * _multiplicativeValue);

        if (_additiveModifiers.Count > 0) finalValue += _additiveValue;

        return finalValue;
    }

    public override void AugmentBaseValue(long value)
    {
        base.AugmentBaseValue(value);
        _baseValue += value;
    }

    protected override void SetAdditiveValue()
    {
        _additiveValue = 0;

        foreach(long modifier in _additiveModifiers)
        {
            _additiveValue += modifier;
        }
    }
}
