using System;
using UnityEngine;

public enum EquipementType
{
    HEAD,
    CHEST,
    LEGS
}

[Serializable]
public class EquipementData
{
    // Item Attributes //

    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private EquipementType _equipementType;

    #region Properties
    public string Name { get => _name; }
    public string Description { get => _description; }
    public Sprite Sprite { get => _sprite; }
    public EquipementType EquipementType { get => _equipementType; }
    #endregion
}
