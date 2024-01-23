using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FloatStat : Stat<float>
{
    public override float GetValue()
    {
        float finalValue = _baseValue;

        if (_multiplicativeModifiers.Count > 0) finalValue *= _multiplicativeValue;

        if (_additiveModifiers.Count > 0) finalValue += _additiveValue;

        return finalValue;
    }

    public override void AugmentBaseValue(float value)
    {
        base.AugmentBaseValue(value);
        _baseValue += value;
    }

    protected override void SetAdditiveValue()
    {
        _additiveValue = 0;

        foreach (float modifier in _additiveModifiers)
        {
            _additiveValue += modifier;
        }
    }
}
