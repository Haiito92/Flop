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
    [SerializeField] private EquipementType _equipementType;

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
        EquipementData = DatabasesManager.Instance.EquipementDatabase.EquipementDatas[0];
        Init();
    }

    public void Init()
    {
        if(EquipementData == null) { return; }

        name = EquipementData.Name;
        _description = EquipementData.Description;
        Image.sprite = EquipementData.Sprite;
        _equipementType = EquipementData.EquipementType;
    }
}
