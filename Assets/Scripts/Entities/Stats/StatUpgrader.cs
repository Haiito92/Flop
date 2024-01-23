using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeType
{
    HEALTH,
    BASIC_ATK_DMG,
    SPECIAL_ATK_DMG
}

public class StatUpgrader : MonoBehaviour
{
    [SerializeField] CharacterStats _characterStats;

    //Curves
    [SerializeField] AnimationCurve _healthUpgradeCurve;
    [SerializeField] AnimationCurve _dmgUpgradeCurve;
    [SerializeField] AnimationCurve _specialDMGUpgradeCurve;
    [SerializeField] AnimationCurve _costCurve;

    //Events for dev
    public event Action<int, int> OnHealthUpgradeChange;
    public event Action<int, int> OnBasicDMGUpgradeChange;
    public event Action<int, int> OnSpecialDMGUpgradeChange;

    //Properties

    public void UpgradeStat(UpgradeType upgradeType)
    {
        switch(upgradeType)
        {
            case UpgradeType.HEALTH:
                UpgradeMaxHealth();
                break;
            case UpgradeType.BASIC_ATK_DMG: 
                UpgradeBaseAttackDamage();
                break;
            case UpgradeType.SPECIAL_ATK_DMG: 
                UpgradeSpecialAttackDamage();
                break;
            default: throw new Exception("No Valid Upgrade Type");
        }
    }

    void UpgradeMaxHealth()
    {
        if (!CanAfford((int)_costCurve.Evaluate(_characterStats.MaxHealth.Level))) return;

        UpgradeLongStat(_characterStats.MaxHealth, _healthUpgradeCurve, out int nextUpgradeValue, out int nextCost);
        _characterStats.CurrentHealth += (long)_healthUpgradeCurve.Evaluate(_characterStats.MaxHealth.Level - 1);

        OnHealthUpgradeChange?.Invoke(nextUpgradeValue, nextCost);
    }

    void UpgradeBaseAttackDamage()
    {
        if (!CanAfford((int)_costCurve.Evaluate(_characterStats.BaseAttackDamage.Level))) return;

        UpgradeLongStat(_characterStats.BaseAttackDamage, _dmgUpgradeCurve, out int nextUpgradeValue, out int nextCost);

        OnBasicDMGUpgradeChange?.Invoke(nextUpgradeValue, nextCost);
    }

    void UpgradeSpecialAttackDamage()
    {
        if (!CanAfford((int)_costCurve.Evaluate(_characterStats.SpecialAttackDamage.Level))) return;

        UpgradeLongStat(_characterStats.SpecialAttackDamage, _specialDMGUpgradeCurve, out int nextUpgradeValue, out int nextCost);

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
        switch (type)
        {
            case UpgradeType.HEALTH:
                EvalutateNextLongStatUpgrade(_characterStats.MaxHealth, _healthUpgradeCurve, out int nextUpgradeValue, out int nextCost);
                OnHealthUpgradeChange?.Invoke(nextUpgradeValue, nextCost);
                break;
            case UpgradeType.BASIC_ATK_DMG:
                EvalutateNextLongStatUpgrade(_characterStats.BaseAttackDamage, _dmgUpgradeCurve, out int nextUpgradeValue2, out int nextCost2);
                OnBasicDMGUpgradeChange.Invoke(nextUpgradeValue2, nextCost2);
                break;
            case UpgradeType.SPECIAL_ATK_DMG:
                EvalutateNextLongStatUpgrade(_characterStats.SpecialAttackDamage, _specialDMGUpgradeCurve, out int nextUpgradeValue3, out int nextCost3);
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
        if (cost > Inventory.Instance.ResourcesInventory.Gold)
        {
            Debug.Log("Can't afford");
            return false;
        }

        Inventory.Instance.ResourcesInventory.RemoveGold(cost);
        return true;
    }
}
