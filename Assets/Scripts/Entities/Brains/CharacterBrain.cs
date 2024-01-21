using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CharacterBrain : BasicBrain
{
    //Fields
    [SerializeField] protected SpecialAttack _specialAttack;

    [SerializeField] protected float _maxSpecialResource;
    protected float _currentSpecialResource = 0.0f;

    protected int _phase = 1;

    //Events for Dev
    public Action OnSpecialAttack;
    public Action<float,float> OnSpecialResourceChange;

    #region Properties
    public float MaxSpecialResource => _maxSpecialResource;
    public float CurrentSpecialResource => _currentSpecialResource;
    public int Phase { get => _phase; set => _phase = value; }

    public Color SpecialResourceColor;
    #endregion

    private void Awake()
    {
        _currentSpecialResource = 0.0f;
    }

    private void Start()
    {
        StartAttackRoutine();
    }

    protected override IEnumerator AttackRoutine()
    {
        throw new NotImplementedException();
    }

    public void DoSpecialAttack()
    {
        _specialAttack.DoSpecialAttack(_target);
    }

    public virtual void ChangePhase(int currentPhase)
    {
        Phase = currentPhase;
    }

    protected override void FindAttacks()
    {
        base.FindAttacks();
        _specialAttack = _actions.GetComponent<SpecialAttack>();
    }
}
