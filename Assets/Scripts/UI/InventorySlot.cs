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
            ChangeItem(draggableItem);
        }
        if(_slotType == EquipementType.NONE)
        {
            ChangeItem(draggableItem);
        }
    }

    void ChangeItem(InventoryItem item)
    {
        item.ParentAfterDrag = transform;
    }
}
