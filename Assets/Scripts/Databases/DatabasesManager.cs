using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabasesManager : MonoBehaviour
{
    // Fields //

    [SerializeField] private EquipementDatabase _equipementDatabase;
    [SerializeField] private EnemyDatabase _enemiesDatabase;

    // Instance //

    private static DatabasesManager _instance;
    public static DatabasesManager Instance => _instance;

    // Properties //

    #region Properties
    public EquipementDatabase EquipementDatabase { get => _equipementDatabase; }
    #endregion

    private void Awake()
    {
        if( _instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
}
