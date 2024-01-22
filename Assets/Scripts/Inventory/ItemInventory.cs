using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventory : MonoBehaviour
{
    [SerializeField] int _size = 52;
    EquipementData[] _equipments;

    #region Properties
    public EquipementData[] Equipments => _equipments;
    #endregion

    private void Awake()
    {
        _equipments = new EquipementData[_size];
    }

    public void Add(EquipementData equipement)
    {
        
    }

    public void Remove()
    {
        
    }
}
