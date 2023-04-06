using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Data/EnemyData", order = 1)]
public class EnemyData : ScriptableObject
{
    public float _speed;
    public int _health;
    public int _damage;
    public int _goldReward;
    public int _scoreReward;
    public string _tag;
}