using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Stat<T>
{
    [SerializeField] protected T _baseValue;

    [SerializeField] protected List<T> _additiveModifiers = new List<T>();
    [SerializeField] protected List<float> _multiplicativeModifiers = new List<float>();

    protected T _additiveValue;
    protected float _multiplicativeValue;

    public abstract T GetValue();

    public void SetValue(T value)
    {
        _baseValue = value;
    }

    public abstract void AugmentBaseValue(T value);

    protected abstract void SetAdditiveValue();

    public void AddAdditiveModifier(T modifier)
    {
        _additiveModifiers.Add(modifier);
        SetAdditiveValue();
    }

    public void RemoveAdditiveModifier(T modifier)
    {
        _additiveModifiers.Remove(modifier);
        SetAdditiveValue();
    }

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
