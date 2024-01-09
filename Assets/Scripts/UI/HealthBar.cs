using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image _fill;

    [SerializeField] CharacterHealth _character;

    private void Awake()
    {
        _character.OnHealthChange += SetHealthFill;
    }

    public void SetHealthFill(long currentHealth, long maxHeath)
    {
        _fill.fillAmount = Mathf.Clamp((float)currentHealth/(float)maxHeath, 0, 1);
    }
}
