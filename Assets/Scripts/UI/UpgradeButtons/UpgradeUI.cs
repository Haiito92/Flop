using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField] CharacterStats _characterStats;

    [SerializeField] TextMeshProUGUI _upgradeAmountText;
    [SerializeField] TextMeshProUGUI _costText;

    [SerializeField] UpgradeType _upgradeType;

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        switch (_upgradeType)
        {
            case UpgradeType.HEALTH:
                _characterStats.OnHealthUpgradeChange += UpdateUpgradeAmountUI;
                break;
            case UpgradeType.BASIC_ATK_DMG:
                _characterStats.OnBasicDMGUpgradeChange += UpdateUpgradeAmountUI;
                break;
            case UpgradeType.SPECIAL_ATK_DMG:
                _characterStats.OnSpecialDMGUpgradeChange += UpdateUpgradeAmountUI;
                break;
            default:
                Debug.LogWarning("UpgradeUI Should have a Type");
                break;
        }

        _characterStats.EvaluateNextUpgrade(_upgradeType);
    }

    void UpdateUpgradeAmountUI(int amount, int cost)
    {
        _upgradeAmountText.text = "+ " + amount.ToString();
        UpdateCostUI(cost);
    }

    void UpdateCostUI(int amount)
    {
        _costText.text = amount.ToString();
    }

    private void OnDisable()
    {
        switch (_upgradeType)
        {
            case UpgradeType.HEALTH:
                _characterStats.OnHealthUpgradeChange -= UpdateUpgradeAmountUI;
                break;
            case UpgradeType.BASIC_ATK_DMG:
                _characterStats.OnBasicDMGUpgradeChange -= UpdateUpgradeAmountUI;
                break;
            case UpgradeType.SPECIAL_ATK_DMG:
                _characterStats.OnSpecialDMGUpgradeChange -= UpdateUpgradeAmountUI;
                break;
            default:
                Debug.LogWarning("UpgradeUI Should have a Type");
                break;
        }
    }
}
