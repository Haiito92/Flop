using UnityEngine;

[CreateAssetMenu(fileName = "New Boss", menuName = "Characters/Boss")]
public class BossData : CharacterData
{
    [SerializeField] private int _bossID;
    [SerializeField] private long _dropChance;
}
