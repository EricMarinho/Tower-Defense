using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MatchWavesData", menuName = "Data/Wave/MatchWavesData", order = 0)]
public class MatchData : ScriptableObject
{
    public List<WaveData> _initialWaves;
    public List<WaveData> _infinitWaves;
    public int _secondsBetweenWaves;
}
