using UnityEngine;

[CreateAssetMenu(fileName = "New Boss", menuName = "Characters/Boss")]
public class BossData : CharacterData
{
    [SerializeField] private ulong _dropChance;
}
