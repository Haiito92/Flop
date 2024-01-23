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

    //Stats
    #region Properties
    public LongStat MaxHealth => _characterHealth.MaxHealth;
    public long CurrentHealth { get { return _characterHealth.CurrentHealth; } set { _characterHealth.CurrentHealth = value; } }
    public LongStat BaseAttackDamage => _characterBrain.BaseAttack.Damage;
    public LongStat SpecialAttackDamage => _characterBrain.SpecialAttack.Damage;
    #endregion
  
}
