using UnityEngine;

[CreateAssetMenu(fileName = "New Boss", menuName = "Characters/Boss")]
public class PlayerData : HeroData
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
