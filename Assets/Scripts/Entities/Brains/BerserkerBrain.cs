using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerserkerBrain : CharacterBrain
{
    [SerializeField] float _specialResourceAdded;

    protected override IEnumerator AttackRoutine()
    {
        while (true)
        {
            if (_target == null)
            {
                
                yield return null;
                continue;
            }

            if (_currentSpecialResource >= _maxSpecialResource)
            {
                _specialAttack.DoSpecialAttack(_target);
                _currentSpecialResource = 0.0f;
                OnSpecialResourceChange?.Invoke(_currentSpecialResource, _maxSpecialResource);
                yield return new WaitForSeconds(_attackSpeed.GetValue());
                continue;
            }

            _basicAttack.Attack(_target, (long)_basicAttack.Damage.GetValue());
            _currentSpecialResource = Mathf.Clamp(_currentSpecialResource + _specialResourceAdded, 0.0f, _maxSpecialResource);
            OnSpecialResourceChange?.Invoke(_currentSpecialResource, _maxSpecialResource);
            yield return new WaitForSeconds(_attackSpeed.GetValue());
        }
    }

    public override void ChangePhase(int currentPhase)
    {
        base.ChangePhase(currentPhase);

        _attackSpeed.SetValue(1.0f/(float)currentPhase);
    }
}
