using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Characters/Character")]
public class CharacterData : ScriptableObject
{
    [SerializeField] private ulong _health;
    [SerializeField] private ulong _damage;
    [SerializeField] private ulong _attackspeed;
    [SerializeField] private ulong _crit;
}
