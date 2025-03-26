using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image _fill;

    [SerializeField] CharacterHealth _character;

    public CharacterHealth Character { get => _character; set => _character = value; }

    private void Awake()
    {
        if(_character != null)_character.OnHealthChange += SetHealthFill;
    }

    public void SetNewCharacter(CharacterHealth character)
    {
        if (_character != null) _character.OnHealthChange -= SetHealthFill;
        _character = character;
        _character.OnHealthChange += SetHealthFill;
    }

    public void SetHealthFill(long currentHealth, long maxHeath)
    {
        _fill.fillAmount = Mathf.Clamp((float)currentHealth/(float)maxHeath, 0, 1);
    }

    private void OnDestroy()
    {
        _character.OnHealthChange -= SetHealthFill;
    }
}
