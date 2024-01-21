using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stat
{
    [SerializeField] float _baseValue = 1f;


    [SerializeField] List<float> _additiveModifiers = new List<float>();
    [SerializeField] List<float> _multiplicativeModifiers = new List<float>();
    
    float _additiveValue = 0f;
    float _multiplicativeValue = 1f;

    public float GetValue()
    {
        float finalValue = (_baseValue * _multiplicativeValue) + _additiveValue;
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
        _additiveValue = 0f;

        foreach(float modifier in _additiveModifiers)
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

    void SetMultiplicativeValue()
    {
        _multiplicativeValue = 1f;

        foreach(float modifier in _multiplicativeModifiers) 
        { 
            _multiplicativeValue += modifier; 
        }
    }

    public void AddMutiplicativeModifier(float modifier)
    {
        _multiplicativeModifiers.Add(modifier);
        SetMultiplicativeValue();
    }
    public void RemoveMutiplicativeModifier(float modifier)
    {
        _multiplicativeModifiers.Remove(modifier);
        SetMultiplicativeValue();
    }
}
