using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField] StatUpgrader _statUpgrader;

    [SerializeField] TextMeshProUGUI _upgradeAmountText;
    [SerializeField] TextMeshProUGUI _costText;

    [SerializeField] UpgradeType _upgradeType;


    public void DoUpgrade()
    {
        _statUpgrader.UpgradeStat(_upgradeType);
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

    #region On Enable/Disable
    private void OnEnable()
    {
        switch (_upgradeType)
        {
            case UpgradeType.HEALTH:
                _statUpgrader.OnHealthUpgradeChange += UpdateUpgradeAmountUI;
                break;
            case UpgradeType.BASIC_ATK_DMG:
                _statUpgrader.OnBasicDMGUpgradeChange += UpdateUpgradeAmountUI;
                break;
            case UpgradeType.SPECIAL_ATK_DMG:
                _statUpgrader.OnSpecialDMGUpgradeChange += UpdateUpgradeAmountUI;
                break;
            default:
                Debug.LogWarning("UpgradeUI Should have a Type");
                break;
        }

        _statUpgrader.EvaluateNextUpgrade(_upgradeType);
    }

    private void OnDisable()
    {
        switch (_upgradeType)
        {
            case UpgradeType.HEALTH:
                _statUpgrader.OnHealthUpgradeChange -= UpdateUpgradeAmountUI;
                break;
            case UpgradeType.BASIC_ATK_DMG:
                _statUpgrader.OnBasicDMGUpgradeChange -= UpdateUpgradeAmountUI;
                break;
            case UpgradeType.SPECIAL_ATK_DMG:
                _statUpgrader.OnSpecialDMGUpgradeChange -= UpdateUpgradeAmountUI;
                break;
            default:
                Debug.LogWarning("UpgradeUI Should have a Type");
                break;
        }
    }
    #endregion
}
