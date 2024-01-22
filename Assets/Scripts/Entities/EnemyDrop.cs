using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    [SerializeField] long _goldDropped;
    [SerializeField] CharacterHealth _enemyHealth;

    #region Properties
    public long GoldDropped {  get { return _goldDropped; } set {  _goldDropped = value; } }
    #endregion 

    private void Reset()
    {
        _enemyHealth = GetComponent<CharacterHealth>();
    }

    private void Start()
    {
        _enemyHealth.OnEndDeath += Drop;
    }

    void Drop()
    {
        Inventory.Instance.ResourcesInventory.AddGold(_goldDropped);
        EquipmentGenerator.Instance.GenerateItem();
    }

    private void OnDestroy()
    {
        _enemyHealth.OnEndDeath -= Drop;
    }
}
