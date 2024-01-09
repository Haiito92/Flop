using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Databases/EquipementDatabase", fileName = "New Equipement Database")]
public class EquipementDatabase : ScriptableObject
{
    [SerializeField] private List<EquipementData> _equipementDatas = new List<EquipementData>();

    public List<EquipementData> EquipementDatas { get => _equipementDatas; }
}
