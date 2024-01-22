using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] public ResourcesInventory ResourcesInventory;
    [SerializeField] public GameObject InventoryContainer;

    #region Singleton
    private static Inventory _instance;
    public static Inventory Instance => _instance;

    void InitSingleton()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(gameObject);
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
}
