using UnityEngine;

public class EntityStats : MonoBehaviour
{
    private long _maxHeath;
    private long _currentHealth;

    #region Properties
    public long MaxHeath { get => _maxHeath; set => _maxHeath = value; }
    public long CurrentHealth { get => _currentHealth; set => _currentHealth = value; }
    #endregion
}
