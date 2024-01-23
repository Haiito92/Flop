using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentGenerator : MonoBehaviour
{
    int _currentId = 1;

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
        int _radValue = Random.Range(0,3);
        int randomIndex = 0;
        switch (_radValue)
        {
            case 0:
                randomIndex = Random.Range(0, 12);
                break;
            case 1:
                randomIndex = Random.Range(13, 26);
                break;
            case 2:
                randomIndex = Random.Range(26, 39);
                break;
            default:
                Debug.Log("Bug");
                break;
        }
        EquipementData equipmentDropped = DatabasesManager.Instance.EquipementDatabase.EquipementDatas[randomIndex];
        equipmentDropped.Id = randomIndex;
        Inventory.Instance.ItemInventory.Add(equipmentDropped);
    }
}
