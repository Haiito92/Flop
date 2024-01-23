using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum UpgradeType
{
    HEALTH,
    BASIC_ATK_DMG,
    SPECIAL_ATK_DMG
}

public class CharacterStats : MonoBehaviour
{
    //Refs
    [SerializeField] CharacterHealth _characterHealth;
    [SerializeField] CharacterBrain _characterBrain;

    //Upgrades Fields
    [SerializeField] AnimationCurve _healthUpgradeCurve;
    [SerializeField] AnimationCurve _dmgUpgradeCurve;
    [SerializeField] AnimationCurve _specialDMGUpgradeCurve;
    [SerializeField] AnimationCurve _costCurve;

    //Events for dev
    public event Action<int,int> OnHealthUpgradeChange;
    public event Action<int,int> OnBasicDMGUpgradeChange;
    public event Action<int,int> OnSpecialDMGUpgradeChange;


    #region Properties
    LongStat MaxHealth => _characterHealth.MaxHealth;
    LongStat BaseAttackDamage => _characterBrain.BaseAttack.Damage;
    LongStat SpecialAttackDamage => _characterBrain.SpecialAttack.Damage;
    #endregion

    public void UpgradeMaxHealth()
    {
        if (!CanAfford((int)_costCurve.Evaluate(MaxHealth.Level))) return;

        UpgradeLongStat(MaxHealth, _healthUpgradeCurve, out int nextUpgradeValue, out int nextCost);
        _characterHealth.CurrentHealth += (long)_healthUpgradeCurve.Evaluate(MaxHealth.Level - 1);

        OnHealthUpgradeChange?.Invoke(nextUpgradeValue, nextCost);
    }

    public void UpgradeBaseAttackDamage()
    {
        if (!CanAfford((int)_costCurve.Evaluate(BaseAttackDamage.Level))) return;

        UpgradeLongStat(BaseAttackDamage, _dmgUpgradeCurve, out int nextUpgradeValue, out int nextCost);

        OnBasicDMGUpgradeChange?.Invoke(nextUpgradeValue, nextCost);
    }

    public void UpgradeSpecialAttackDamage()
    {
        if (!CanAfford((int)_costCurve.Evaluate(SpecialAttackDamage.Level))) return;

        UpgradeLongStat(SpecialAttackDamage, _specialDMGUpgradeCurve, out int nextUpgradeValue, out int nextCost);

        OnSpecialDMGUpgradeChange?.Invoke(nextUpgradeValue, nextCost);
    }

    void UpgradeLongStat(LongStat stat, AnimationCurve upgradeCurve, out int nextUpgradeValue, out int nextCost)
    {

        int upgradeValue = (int)upgradeCurve.Evaluate(stat.Level);
        stat.AugmentBaseValue(upgradeValue);

        EvalutateNextLongStatUpgrade(stat, upgradeCurve, out nextUpgradeValue, out nextCost);
    }

    public void EvaluateNextUpgrade(UpgradeType type)
    {
        switch(type)
        {
            case UpgradeType.HEALTH:
                EvalutateNextLongStatUpgrade(MaxHealth, _healthUpgradeCurve, out int nextUpgradeValue, out int nextCost);
                OnHealthUpgradeChange?.Invoke(nextUpgradeValue, nextCost);
                break;
            case UpgradeType.BASIC_ATK_DMG:
                EvalutateNextLongStatUpgrade(MaxHealth, _healthUpgradeCurve, out int nextUpgradeValue2, out int nextCost2);
                OnBasicDMGUpgradeChange.Invoke(nextUpgradeValue2, nextCost2);
                break;
            case UpgradeType.SPECIAL_ATK_DMG:
                EvalutateNextLongStatUpgrade(MaxHealth, _healthUpgradeCurve, out int nextUpgradeValue3, out int nextCost3);
                OnSpecialDMGUpgradeChange?.Invoke(nextUpgradeValue3, nextCost3);
                break;
            default:
                Debug.LogWarning("Error of Upgrade Type");
                return;
        }
    }

    private void EvalutateNextLongStatUpgrade(LongStat stat, AnimationCurve upgradeCurve, out int nextUpgradeValue, out int nextCost)
    {
        nextUpgradeValue = (int)upgradeCurve.Evaluate(stat.Level);
        nextCost = (int)_costCurve.Evaluate(stat.Level);
    }

    bool CanAfford(int cost)
    {
        if(cost > Inventory.Instance.ResourcesInventory.Gold)
        {
            Debug.Log("Can't afford");
            return false;
        }
        return true;
    }
}
