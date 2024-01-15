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
    [SerializeField] SpecialAttack _specialAttack;

    [SerializeField] float _maxSpecialResource;
    float _currentSpecialResource = 0.0f;
    [SerializeField] float _specialResourceAdded;

    //Events for Dev
    public event Action<float,float> OnSpecialResourceChange;

    #region Properties
    public float CurrentSpecialResource => _currentSpecialResource;
    public float MaxSpecialResource => _maxSpecialResource;
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
        while (true)
        {
            if(_target == null)
            {
                yield return null;
                continue;   
            }
            if (_currentSpecialResource >= _maxSpecialResource)
            {
                _specialAttack.DoSpecialAttack(_target);
                _currentSpecialResource = 0.0f;
                OnSpecialResourceChange?.Invoke(_currentSpecialResource, _maxSpecialResource);
            }
            else
            {
                _basicAttack.Attack(_target, _basicAttack.Damage);
                _currentSpecialResource = Mathf.Clamp(_currentSpecialResource + _specialResourceAdded, 0.0f, _maxSpecialResource);
                OnSpecialResourceChange?.Invoke(_currentSpecialResource, _maxSpecialResource);
            }
            yield return new WaitForSeconds(_attackSpeed);
        }
    }

    protected override void FindAttacks()
    {
        base.FindAttacks();
        _specialAttack = _actions.GetComponent<SpecialAttack>();
    }
}
