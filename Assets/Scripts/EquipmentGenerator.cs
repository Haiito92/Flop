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
                randomIndex = GenerationProbability(0, 121);
                break;
            case 1:
                randomIndex = GenerationProbability(0, 121) + 12;
                break;
            case 2:
                randomIndex = GenerationProbability(0, 121) + 25;
                break;
            default:
                Debug.Log("Bug");
                break;
        }
        EquipementData equipmentDropped = DatabasesManager.Instance.EquipementDatabase.EquipementDatas[randomIndex];
        equipmentDropped.Id = randomIndex;
        Inventory.Instance.ItemInventory.Add(equipmentDropped);
    }

    private int GenerationProbability(int min, int max)
    {
        int random = Random.Range(min, max);

        if(random >= min && random < min + 5)
        {
            return 0;
        }
        else if (random >= min && random < min + 10)
        {
            return 1;
        }
        else if(random >= min && random < min + 20)
        {
            return 2;
        }
        else if(random >= min && random < min + 30)
        {
            return 3;
        }
        else if(random >= min && random < min + 40)
        {
            return 4;
        }
        else if(random >= min && random < min + 50)
        {
            return 5;
        }
        else if (random >= min && random < min + 60)
        {
            return 6;
        }
        else if (random >= min && random < min + 70)
        {
            return 7;
        }
        else if (random >= min && random < min + 80)
        {
            return 8;
        }
        else if (random >= min && random < min + 90)
        {
            return 9;
        }
        else if (random >= min && random < min + 100)
        {
            return 10;
        }
        else if (random >= min && random < min + 110)
        {
            return 11;
        }
        else if (random >= min && random <= min + 120)
        {
            return 12;
        }
        return 0;
    }
}
