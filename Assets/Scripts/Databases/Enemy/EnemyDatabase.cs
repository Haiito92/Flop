using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Databases/EnemyDatabase", fileName = "New Enemy Database")]
public class EnemyDatabase : ScriptableObject
{
    [SerializeField] List<EnemyData> enemyDatas = new List<EnemyData>();
    public List<EnemyData> EnemyDatas => enemyDatas;
}
