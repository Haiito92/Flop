using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private EquipementType _slotType;

    public event Action<InventoryItem> OnStatCheck;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        InventoryItem draggableItem = dropped.GetComponent<InventoryItem>();
        EquipementController draggableController = dropped.GetComponent<EquipementController>();
        if(draggableController.EquipementData.EquipementType == _slotType)
        {
            draggableItem.ParentAfterDrag = transform;
            OnStatCheck?.Invoke(draggableItem);
        }
        if(_slotType == EquipementType.NONE)
        {
            draggableItem.ParentAfterDrag = transform;
            OnStatCheck?.Invoke(draggableItem);
        }
    }
}
