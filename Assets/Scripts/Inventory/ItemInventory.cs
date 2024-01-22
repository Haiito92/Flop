using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventory : MonoBehaviour
{
    [SerializeField] int _size = 52;

    public event Action<EquipementData[]> OnInventoryChange;

    #region Properties
    public EquipementData[] Equipments { get; private set; }
    #endregion

    private void Awake()
    {
        Equipments = new EquipementData[_size];
    }

    public void Add(EquipementData equipement)
    {
        int count = 0;
        foreach(EquipementData eq in Equipments)
        {
            if (eq == null) return;
            if(equipement.Id == eq.Id)
            {
                return;
            }
            count++;
        }
        Equipments[count] = equipement;
        OnInventoryChange?.Invoke(Equipments);
    }

    public void Remove()
    {
        
    }
}
