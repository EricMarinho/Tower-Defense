using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnerData", menuName = "Data/SpawnerData", order = 2)]
public class SpawnerData : ScriptableObject
{
    public float _spawnRateMin;
    public float _spawnRateMax;
    public List<string> _enemyTags = new List<string>();
}
