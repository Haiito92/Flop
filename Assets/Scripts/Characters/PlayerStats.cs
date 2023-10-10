using UnityEngine;

public class PlayerStats : HeroStats
{
    [SerializeField] private long _clickDamage;

    #region Properties
    public long ClickDamage
    {
        get { return _clickDamage; }
        set { _clickDamage = value; }
    }
    #endregion
}
