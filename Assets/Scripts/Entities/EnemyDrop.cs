using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    [SerializeField] long _goldDropped;
    [SerializeField] CharacterHealth _enemyHealth;

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
    }

    private void OnDestroy()
    {
        _enemyHealth.OnEndDeath -= Drop;
    }
}
