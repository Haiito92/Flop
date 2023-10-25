using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipementController : MonoBehaviour
{
    // Data stored in Item Controller //
    private EquipementData _equipementData;

    // Fields //
    [SerializeField] private string _description;
    [SerializeField] private EquipementType _equipementType;

    //References
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _equipementData = DatabasesManager.Instance.EquipementDatabase.EquipementDatas[0];
        Init();
    }

    public void Init()
    {
        if(_equipementData == null) { return; }

        name = _equipementData.Name;
        _description = _equipementData.Description;
        _spriteRenderer.sprite = _equipementData.Sprite;
        _equipementType = _equipementData.EquipementType;
    }
}
