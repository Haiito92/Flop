using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentGenerator : MonoBehaviour
{

    #region Singleton
    static EquipmentGenerator _instance;
    public static EquipmentGenerator Instance => _instance;

    private void InitSingleton()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion
    private void Awake()
    {
        InitSingleton();
    }

    public void GenerateItem()
    {
        int randomIndex = Random.Range(0, DatabasesManager.Instance.EquipementDatabase.EquipementDatas.Count);
        EquipementData equipmentDropped = DatabasesManager.Instance.EquipementDatabase.EquipementDatas[randomIndex];
        Inventory.Instance.ItemInventory.Add(equipmentDropped);
    }
}
