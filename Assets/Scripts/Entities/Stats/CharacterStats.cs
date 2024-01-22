using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    

    //Refs
    [SerializeField] CharacterHealth _characterHealth;
    [SerializeField] CharacterBrain _characterBrain;

    //Stats

    #region Properties
    LongStat MaxHealth => _characterHealth.MaxHealth;
    LongStat BaseAttackDamage => _characterBrain.BaseAttack.Damage;
    LongStat SpecialAttackDamage => _characterBrain.SpecialAttack.Damage;
    #endregion

    public void UpgradeMaxHealth(int value)
    {
        MaxHealth.AugmentBaseValue(value);
    }
    public void UpgradeBaseAttackDamage(int value)
    {
        BaseAttackDamage.AugmentBaseValue(value);
    }
    public void UpgradeSpecialAttackDamage(int value)
    {
        SpecialAttackDamage.AugmentBaseValue(value);
    }
}
