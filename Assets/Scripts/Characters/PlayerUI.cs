using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private Image _healthFill;

    private void Awake()
    {
        _playerStats.HealthChange += UpdateHealthUI;
    }

    private void UpdateHealthUI()
    {
        _healthFill.fillAmount = (float)_playerStats.Health / (float)_playerStats.MaxHealth;
    }
}
