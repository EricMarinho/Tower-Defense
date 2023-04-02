using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveData", menuName = "Data/Wave/WaveData", order = 1)]
public class WaveData : ScriptableObject
{
    public int _enemiesNumber;
    public float _spawnRateMin;
    public float _spawnRateMax;
    public List<string> _enemyTags = new List<string>();
}
