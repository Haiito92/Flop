using System;
using UnityEngine;

public enum EquipementType
{
    NONE,
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
    [SerializeField] private int _atk;
    [SerializeField] private int _def;

    private int _id = 0;

    #region Properties
    public string Name { get => _name; }
    public string Description { get => _description; }
    public Sprite Sprite { get => _sprite; }
    public EquipementType EquipementType { get => _equipementType; }
    public int Atk { get => _atk; set => _atk = value; }
    public int Def { get => _def; set => _def = value; }
    public int Id { get => _id; set => _id = value; }

    #endregion

    public EquipementData() 
    {
        _name = "";
        _description = "";
        _sprite = null;
        _equipementType = EquipementType.NONE;
        _atk = 0;
        _def = 0;
    }
}
