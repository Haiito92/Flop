using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField] protected List<float> _multiplicativeModifiers = new List<float>();

    protected float _multiplicativeValue;

    void SetMultiplicativeValue()
    {
        _multiplicativeValue = 0f;

        foreach (float modifier in _multiplicativeModifiers)
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
