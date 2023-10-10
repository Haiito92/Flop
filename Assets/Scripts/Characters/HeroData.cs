using UnityEngine;

[CreateAssetMenu(fileName = "New Hero", menuName = "Characters/Hero")]
public class HeroData : ScriptableObject
{
    [SerializeField] private long _maxHealth;
    [SerializeField] private long _health;
    [SerializeField] private long _damage;
    [SerializeField] private long _attackspeed;
    [SerializeField] private long _crit;

    #region Properties

    public long MaxHealth => _maxHealth;
    public long Health
    {
        get { return _health; }
        set { 
                _health = (long)Mathf.Clamp(value, 0, _maxHealth);
            }
    }

    public long Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    #endregion

}
