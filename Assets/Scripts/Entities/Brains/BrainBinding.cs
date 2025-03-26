using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainBinding : MonoBehaviour
{
    //Refs
    [SerializeField] CharacterBrain _currentBrain;

    FightManager _fightManager;

    //Event for devs
    public event Action<CharacterBrain> OnBrainChange;

    #region Properties
    public CharacterBrain CurrentBrain => _currentBrain;
    #endregion

    private void Reset()
    {
        _currentBrain = GetComponent<CharacterBrain>();
    }

    private void Start()
    {

        _fightManager = FightManager.Instance;
        _fightManager.OnNextSegment += CheckSegment;
    }

    public void SetCurrentBrainTarget(CharacterHealth target)
    {
        _currentBrain.SetTarget(target);
    }

    void CheckSegment(int currentSegment)
    {
        if(currentSegment == 1)
        {
            _currentBrain.ChangePhase(1);
        }
        if(currentSegment == 6)
        {
            _currentBrain.ChangePhase(2);
        }
    }

    public void ChangeBrain(CharacterBrain newBrain)
    {
        _currentBrain.StopAttackRoutine();
        CharacterBrain oldBrain = _currentBrain;

        _currentBrain = newBrain;

        _currentBrain.BaseAttack.Damage = oldBrain.BaseAttack.Damage;
        _currentBrain.SpecialAttack.Damage = oldBrain.SpecialAttack.Damage;

        _currentBrain.StartAttackRoutine();
        OnBrainChange?.Invoke(_currentBrain);
    }
}
