using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FloatStat : Stat
{
    [SerializeField] float _baseValue = 1;

    [SerializeField] List<float> _additiveModifiers = new List<float>();

    float _additiveValue;
    public float GetValue()
    {
        float finalValue = _baseValue;

        if (_multiplicativeModifiers.Count > 0) finalValue *= _multiplicativeValue;

        if (_additiveModifiers.Count > 0) finalValue += _additiveValue;

        return finalValue;
    }

    public void SetValue(float value)
    {
        _baseValue = value;
    }

    public void AugmentBaseValue(float value)
    {
        _baseValue += value;
    }

    void SetAdditiveValue()
    {
        _additiveValue = 0;

        foreach (float modifier in _additiveModifiers)
        {
            _additiveValue += modifier;
        }
    }

    public void AddAdditiveModifier(float modifier)
    {
        _additiveModifiers.Add(modifier);
        SetAdditiveValue();
    }

    public void RemoveAdditiveModifier(float modifier)
    {
        _additiveModifiers.Remove(modifier);
        SetAdditiveValue();
    }
}
