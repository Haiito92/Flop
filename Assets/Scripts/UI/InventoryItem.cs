using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public enum ItemClass
    {
        BOOTS,
        CHESTPLATE
    }

    [Header("UI")]
    public Image image;
    [Header("Type")]
    public ItemClass type = ItemClass.BOOTS;

    [HideInInspector] private Transform parentAfterDrag;

    public Transform ParentAfterDrag { get => parentAfterDrag; set => parentAfterDrag = value; }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ParentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(ParentAfterDrag);
        image.raycastTarget = true;
    }
}
