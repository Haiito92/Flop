using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public delegate void StatChange();

public class HeroStats : MonoBehaviour
{
    // Stats //
    [SerializeField] private Stat _maxHealth;
    [SerializeField] private long _health;
    [SerializeField] private Stat _damage;
    [SerializeField] private Stat _attackspeed;
    [SerializeField] private Stat _crit;

    // Events //
    public StatChange HealthChange;

    #region Properties
    public Stat MaxHealth => _maxHealth;
    public long Health
    {
        get { return _health; }
        set { 
                _health = (long)Mathf.Clamp(value, 0, _maxHealth.BaseValue);
                HealthChange?.Invoke();
                UIManager.Instance.HeroHealthFill.fillAmount = (float)_health /(float)_maxHealth.BaseValue;
            }
    }
    public Stat Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    #endregion

    // Stats Scaling //
    private void Awake()
    {
        _health = _maxHealth.BaseValue;
    }

    public void ScaleStats(int level)
    {
        _maxHealth.ScaleStat(level);
        _damage.ScaleStat(level);
    }
}
