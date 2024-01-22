using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventoryUI : MonoBehaviour
{
    [SerializeField] List<InventorySlot> _slots = new List<InventorySlot>();

    [SerializeField] public GameObject _itemPrefab;

    private GameObject _instanceOfGO;

    [SerializeField] ItemInventory _itemInventory;

    EquipementData[] CachedEquipments { get; set; }

    private void Start()
    {
        Inventory.Instance.ItemInventory.OnInventoryChange += UpdateUI;
    }


    void UpdateUI(EquipementData[] equipments)
    {
        for(int i = 0; i < equipments.Length; i++)
        {
            _instanceOfGO = Instantiate(_itemPrefab, _slots[i].transform);
            _instanceOfGO.GetComponent<EquipementController>().Init(equipments[i].Id);
        }
    }
}
