using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private Stat _maxHealth;
    [SerializeField] private long _health;
    [SerializeField] private Stat _damage;
    [SerializeField] private Stat _clickDamage;
    [SerializeField] private Stat _attackspeed;
    [SerializeField] private Stat _crit;

    public StatChange HealthChange;

    #region Properties
    public Stat MaxHealth => _maxHealth;
    public long Health
    {
        get { return _health; }
        set
        {
            _health = (long)Mathf.Clamp(value, 0, _maxHealth.BaseValue);
            HealthChange?.Invoke();
            UIManager.Instance.PlayerHealthFill.fillAmount = (float)_health / (float)_maxHealth.BaseValue;
        }
    }
    public Stat Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }
    public Stat ClickDamage
    {
        get { return _clickDamage; }
        set { _clickDamage = value; }
    }

    #endregion

    private void Awake()
    {
        _health = _maxHealth.BaseValue;
    }
}
