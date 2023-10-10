using UnityEngine;
using UnityEngine.UI;

public class HeroUI : MonoBehaviour
{
    [SerializeField] private HeroStats _heroStats;
    
    [SerializeField] private Image _healthFill;

    private void Awake()
    {
        _heroStats.HealthChange += UpdateHealthUI;
    }

    private void UpdateHealthUI()
    {
        _healthFill.fillAmount = (float)_heroStats.Health/(float)_heroStats.MaxHealth;
    }
}
