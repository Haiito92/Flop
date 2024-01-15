using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpecialResourceBar : MonoBehaviour
{
    //Refs to components out of go
    [SerializeField] Image _fill;

    [SerializeField] PlayerBrains _playerBrain;
    CharacterBrain _currentBrain;

    private void Start()
    {
        _playerBrain.OnBrainChange += SetNewBrain;

        SetNewBrain(_playerBrain.CurrentBrain);
        UpdateFill(_currentBrain.CurrentSpecialResource, _currentBrain.MaxSpecialResource);
        _currentBrain.OnSpecialResourceChange += UpdateFill;
    }

    void UpdateFill(float currentValue, float maxValue)
    {
        _fill.fillAmount = currentValue / maxValue;
    }

    void SetNewBrain(CharacterBrain newBrain)
    {
        if(_currentBrain != null) _currentBrain.OnSpecialResourceChange -= UpdateFill;
        _currentBrain = newBrain;
        _fill.color = _currentBrain.SpecialResourceColor;
        _currentBrain.OnSpecialResourceChange += UpdateFill;
        UpdateFill(_currentBrain.CurrentSpecialResource, _currentBrain.MaxSpecialResource);
    }

    private void OnDestroy()
    {
        _currentBrain.OnSpecialResourceChange -= UpdateFill;
    }
}
