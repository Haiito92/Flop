using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrains : MonoBehaviour
{
    //Refs
    [SerializeField] CharacterBrain _brainOne;
    [SerializeField] CharacterBrain _brainTwo;

    CharacterBrain _currentBrain;

    FightManager _fightManager;

    //Event for devs
    public event Action<CharacterBrain> OnBrainChange;

    #region Properties
    public CharacterBrain CurrentBrain => _currentBrain;
    #endregion

    private void Awake()
    {
        _currentBrain = _brainOne;
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
            ChangeBrain(_brainOne);
        }
        if(currentSegment == 5)
        {
            ChangeBrain(_brainTwo);
        }
    }

    void ChangeBrain(CharacterBrain newBrain)
    {
        _currentBrain.StopAttackRoutine();
        _currentBrain = newBrain;
        _currentBrain.StartAttackRoutine();
        OnBrainChange?.Invoke(_currentBrain);
    }
}
