using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private EquipementType _slotType;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        InventoryItem draggableItem = dropped.GetComponent<InventoryItem>();
        EquipementController draggableController = dropped.GetComponent<EquipementController>();
        if(draggableController.EquipementData.EquipementType == _slotType)
        {
            draggableItem.ParentAfterDrag = transform;
        }
        if(_slotType == EquipementType.NONE)
        {
            draggableItem.ParentAfterDrag = transform;
        }
    }
}
