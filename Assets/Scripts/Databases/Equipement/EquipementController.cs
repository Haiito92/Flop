using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipementController : MonoBehaviour
{
    // Data stored in Item Controller //
    private EquipementData _equipementData;

    // Fields //
    [SerializeField] private string _description;
    [SerializeField] private int _atk;
    [SerializeField] private int _def;
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

    private void Start()
    {

    }

    public void Init(int _itemID)
    {
        EquipementData = DatabasesManager.Instance.EquipementDatabase.EquipementDatas[_itemID];
        if (EquipementData == null) { return; }
        name = EquipementData.Name;
        _atk = EquipementData.Atk;
        _def = EquipementData.Def;
        _description = EquipementData.Description;
        Image.sprite = EquipementData.Sprite;
        _equipementType = EquipementData.EquipementType;
    }
}
