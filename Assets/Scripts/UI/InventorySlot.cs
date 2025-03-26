using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private EquipementType _slotType;

    [SerializeField] private GameObject _itemPrefab;

    [SerializeField] StuffToolTip _toolTip;

    private GameObject _instanceOfGO;

    public event Action<InventoryItem> OnStatCheck;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        InventoryItem draggableItem = dropped.GetComponent<InventoryItem>();
        EquipementController draggableController = dropped.GetComponent<EquipementController>();

        if(draggableController.EquipementData.EquipementType == _slotType)
        {
            if (this.transform.childCount > 0)
            {
                foreach(Transform child in transform)
                {
                    if(child.GetComponent<EquipementController>().EquipementData.Id != draggableController.EquipementData.Id)
                    {
                        Destroy(child.gameObject);
                        _instanceOfGO = Instantiate(_itemPrefab, this.transform);
                        _instanceOfGO.GetComponent<EquipementController>().Init(draggableController.EquipementData.Id);
                        _instanceOfGO.GetComponent<InventoryItem>().ToolTip = _toolTip;
                        OnStatCheck?.Invoke(_instanceOfGO.GetComponent<InventoryItem>());
                    }
                }
            } else
            {
                _instanceOfGO = Instantiate(_itemPrefab, this.transform);
                _instanceOfGO.GetComponent<EquipementController>().Init(draggableController.EquipementData.Id);
                _instanceOfGO.GetComponent<InventoryItem>().ToolTip = _toolTip;
                OnStatCheck?.Invoke(_instanceOfGO.GetComponent<InventoryItem>());
            }

        }
    }
}
