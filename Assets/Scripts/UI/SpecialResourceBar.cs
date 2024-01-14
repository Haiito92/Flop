using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialResourceBar : MonoBehaviour
{
    //Refs to components out of go
    [SerializeField] Image _fill;

    [SerializeField] PlayerBrain _playerBrain;

    private void Start()
    {
        UpdateFill(_playerBrain.CurrentSpecialResource, _playerBrain.MaxSpecialResource);
        _playerBrain.OnSpecialResourceChange += UpdateFill;
    }

    void UpdateFill(float currentValue, float maxValue)
    {
        _fill.fillAmount = currentValue / maxValue;
    }
}
