using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Characters/Character")]
public class CharacterData : ScriptableObject
{
    [SerializeField] private long _maxHealth;
    [SerializeField] private long _health;
    [SerializeField] private long _damage;
    [SerializeField] private long _attackspeed;
    [SerializeField] private long _crit;

    #region Properties
    public long Health
    {
        get { return _health; }
        set { 
                _health = (long)Mathf.Clamp(value, 0, _maxHealth);
            }
    }

    #endregion

}
