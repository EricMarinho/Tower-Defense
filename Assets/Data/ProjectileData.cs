using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Projectile Data", menuName = "Data/Defenses/Projectile Data", order = 1)]
public class ProjectileData : ScriptableObject
{
    public string _tag;
    public int _damage;
    public float _speed;
}
