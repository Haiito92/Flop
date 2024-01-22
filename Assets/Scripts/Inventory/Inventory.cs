using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] ResourcesInventory _resourcesInventory;
    [SerializeField] ItemInventory _itemInventory;

    public ResourcesInventory ResourcesInventory => _resourcesInventory;
    public ItemInventory ItemInventory => _itemInventory;

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

    private void Reset()
    {
        _resourcesInventory = GetComponent<ResourcesInventory>();
        _itemInventory = GetComponent<ItemInventory>();
    }

    private void Awake()
    {
        InitSingleton();
    }
}
