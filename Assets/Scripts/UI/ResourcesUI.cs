using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourcesUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _goldsText;

    [SerializeField] ResourcesInventory _resources;

    private void Start()
    {
        _resources = Inventory.Instance.ResourcesInventory;
        _resources.OnGoldChanged += UpdateGolds;

        UpdateGolds(_resources.Gold);
    }

    void UpdateGolds(long value)
    {
        _goldsText.text = value.ToString();
    }
}
