using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Defenses Data", menuName = "Data/Defenses/Defenses Data", order = 0)]
public class DefenseData : ScriptableObject
{
    public string _name;
    public int _buyPrice;
    public int _upgradePrice;
    public int _maxUpgradeLevel;
    public float _fireRate;
}