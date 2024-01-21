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
                OnSpecialAttack?.Invoke();//_specialAttack.DoSpecialAttack(_target);
                _currentSpecialResource = 0.0f;
                OnSpecialResourceChange?.Invoke(_currentSpecialResource, _maxSpecialResource);
                yield return new WaitForSeconds(_attackSpeed.GetValue());
                continue;
            }

            OnBasicAttack?.Invoke(); //_basicAttack.Attack(_target, (long)_basicAttack.Damage.GetValue());
            _currentSpecialResource = Mathf.Clamp(_currentSpecialResource + _specialResourceAdded, 0.0f, _maxSpecialResource);
            OnSpecialResourceChange?.Invoke(_currentSpecialResource, _maxSpecialResource);
            yield return new WaitForSeconds(_attackSpeed.GetValue());
        }
    }

    public override void ChangePhase(int currentPhase)
    {
        if (currentPhase == 1 && Phase == 2)
        {
            _attackSpeed.RemoveMutiplicativeModifier(1f / Phase);
        }

        base.ChangePhase(currentPhase);

        
        if(Phase == 2)
        {
            _attackSpeed.AddMutiplicativeModifier(1f / Phase);
        }
    }
}
