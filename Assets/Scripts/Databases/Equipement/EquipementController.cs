using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipementController : MonoBehaviour
{
    // Data stored in Item Controller /
    private EquipementData _equipementData;

    // Fields //
    [SerializeField] private string _description;
    [SerializeField] private int _atk;
    [SerializeField] private int _health;
    [SerializeField] private EquipementType _equipementType;
    [SerializeField] private int _itemID;

    //References
    private Image _image;

    public Image Image { get => _image; set => _image = value; }
    public EquipementData EquipementData { get => _equipementData; set => _equipementData = value; }

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void Init(int _itemID)
    {
        Init(DatabasesManager.Instance.EquipementDatabase.EquipementDatas[_itemID]);
    }

    public void Init(EquipementData data)
    {
        EquipementData = data;
        if (EquipementData == null) { return; }
        name = EquipementData.Name;
        _atk = EquipementData.Atk;
        _health = EquipementData.Health;
        _description = EquipementData.Description;
        Image.sprite = EquipementData.Sprite;
        _equipementType = EquipementData.EquipementType;
    }
}
