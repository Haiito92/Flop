using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    [SerializeField] CharacterStats _playerStats;
    [SerializeField] List<InventorySlotBoss> _equipmentSlots;

    private void Start()
    {
        if(_equipmentSlots.Count > 0)
        {
            foreach(InventorySlotBoss slot in _equipmentSlots)
            {
                slot.OnEQDChange += ChangeEquipment;
            }
        }   
    }

    void ChangeEquipment(EquipementData oldEquipment, EquipementData newEquipment)
    {
        if(oldEquipment != null) Unequip(oldEquipment);

        if(newEquipment != null) Equip(newEquipment);
    }

    void Equip(EquipementData newEquipment)
    {
        _playerStats.MaxHealth.AddAdditiveModifier(newEquipment.Health);
        _playerStats.CurrentHealth += newEquipment.Health;

        _playerStats.BaseAttackDamage.AddAdditiveModifier(newEquipment.Atk);
    }

    void Unequip(EquipementData oldEquipment)
    {
        _playerStats.MaxHealth.RemoveAdditiveModifier(oldEquipment.Health);
        _playerStats.CurrentHealth -= oldEquipment.Health;

        _playerStats.BaseAttackDamage.RemoveAdditiveModifier(oldEquipment.Atk);
    }

    private void OnDisable()
    {
        if (_equipmentSlots.Count > 0)
        {
            foreach (InventorySlotBoss slot in _equipmentSlots)
            {
                slot.OnEQDChange += ChangeEquipment;
            }
        }
    }
}
