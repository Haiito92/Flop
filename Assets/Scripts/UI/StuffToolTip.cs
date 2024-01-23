using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StuffToolTip : ToolTip_UI
{
    [SerializeField] TextMeshProUGUI _atkValue;
    [SerializeField] TextMeshProUGUI _defValue;
    [SerializeField] TextMeshProUGUI _nameValue;

    private void Awake()
    {
        HideToolTip();
    }

    public void SetStats(EquipementController _stats)
    {
        SetText(_atkValue, _stats.EquipementData.Atk);
        SetText(_defValue, _stats.EquipementData.Health);
        SetText(_nameValue, _stats.EquipementData.Name);
        Color color = new Color(0,0,0,1);
        switch (_stats.EquipementData.EquipementType)
        {
            case EquipementType.CHEST:
                color = new Color(166, 0, 255, 1);
                break;
            case EquipementType.HEAD:
                color = new Color(255, 0, 0, 1);
                break;
            case EquipementType.LEGS:
                color = new Color(0, 0, 0, 1);
                break;
            case EquipementType.NONE:
                color = new Color(120, 255, 105, 1);
                break;
            default:
                Debug.Log("Error With Switch State");
                break;
        }
        SetColor(_nameValue, color);
    }
}
