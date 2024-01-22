using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventory : MonoBehaviour
{
    List<EquipementData> _equipments = new List<EquipementData>();

    public void Add(EquipementData equipment)
    {
        _equipments.Add(equipment);
    }

    public void Remove(EquipementData equipment)
    {
        _equipments.Remove(equipment);
    }
}
