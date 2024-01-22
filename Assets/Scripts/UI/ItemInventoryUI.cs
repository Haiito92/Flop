using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventoryUI : MonoBehaviour
{
    [SerializeField] List<InventorySlot> _slots = new List<InventorySlot>();

    [SerializeField] GameObject _itemPrefab;

    EquipementData[] CachedEquipments { get; set; }


    void UpdateUI(EquipementData[] equipments)
    {
        
    }
}
