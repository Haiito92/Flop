using UnityEngine;

[CreateAssetMenu(fileName ="New TestData", menuName = "Characters/TestData")]
public class TestData : ScriptableObject
{
    [SerializeField] private long _maxHealth;
    [SerializeField] private long _health;
    [SerializeField] private long _damage;

    public long MaxHealth => _maxHealth;
    public long Health
    {
        get { return _health; }
        set { _health = (long)Mathf.Clamp(value, 0, _maxHealth); }
    }

    public long Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }
}
