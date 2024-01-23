using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlotBoss : MonoBehaviour
{
    [SerializeField] InventorySlot _invSlot;

    private EquipementData _eqd;

    public event Action<EquipementData> OnEQDChange;

    public EquipementData EQD { get => _eqd; set => _eqd = value; }

    private void Awake()
    {
        _invSlot = transform.GetComponent<InventorySlot>();
        _invSlot.OnStatCheck += _invSlot_OnStatCheck;
        
    }

    private void _invSlot_OnStatCheck(InventoryItem InvIt)
    {
        EQD = InvIt.Equipment.EquipementData;
        OnEQDChange?.Invoke(EQD);
        //Recup les stats que tu veux de l'item sur le boss AKA son atk def etc ...
        //EX : EquipementData.Atk
    }
}
