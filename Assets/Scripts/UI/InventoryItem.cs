using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Visual")]
    public Image image;

    [Header("UI")]
    [SerializeField] StuffToolTip _toolTip;

    [HideInInspector] private Transform parentAfterDrag;

    private EquipementController equipment;

    public Transform ParentAfterDrag { get => parentAfterDrag; set => parentAfterDrag = value; }
    public EquipementController Equipment { get => equipment; set => equipment = value; }
    public StuffToolTip ToolTip { get => _toolTip; set => _toolTip = value; }

    private void Awake()
    {
        equipment = GetComponent<EquipementController>();
        image = GetComponent<Image>();
    }
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        _toolTip.ShowToolTip();
        _toolTip.SetStats(equipment);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _toolTip.HideToolTip();
    }
}
