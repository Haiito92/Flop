using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerResourcesUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _goldsText;

    [SerializeField] PlayerResources _playerRessources;

    private void Start()
    {
        _playerRessources.OnGoldChanged += UpdateGolds;

        UpdateGolds(_playerRessources.Golds);
    }

    void UpdateGolds(long value)
    {
        _goldsText.text = value.ToString();
    }
}
