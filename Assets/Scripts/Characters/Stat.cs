using System;
using UnityEngine;

[Serializable]
public class Stat
{
    [SerializeField] private long _baseValue;
    [SerializeField] private AnimationCurve _scalingCurve;


    #region Properties
    public long BaseValue { get => _baseValue; set => _baseValue = value; }
    #endregion

    public void ScaleStat(int level)
    {
        _baseValue = (long)_scalingCurve.Evaluate(level);
    }
}
