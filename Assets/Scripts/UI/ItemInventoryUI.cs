using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventoryUI : MonoBehaviour
{
    [SerializeField] List<InventorySlot> _slots = new List<InventorySlot>();

    [SerializeField] public GameObject _itemPrefab;

    [SerializeField] StuffToolTip _toolTip;

    private GameObject _instanceOfGO;

    EquipementData[] CachedEquipments { get; set; }

    private void Start()
    {
        Inventory.Instance.ItemInventory.OnInventoryChange += UpdateUI;
    }


    void UpdateUI(EquipementData[] equipments)
    {
        for(int i = 0; i < equipments.Length; i++)
        {
            if (equipments[i] == null) return;
            for(int j = 0; j < _slots.Count; j++)
            {
                if(equipments[i].Id == j && _slots[j].transform.childCount <= 0)
                {
                    _instanceOfGO = Instantiate(_itemPrefab, _slots[j].transform);
                    _instanceOfGO.GetComponent<EquipementController>().Init(equipments[i].Id);
                    _instanceOfGO.GetComponent<InventoryItem>().ToolTip = _toolTip;
                }
            }
        }
    }
}
