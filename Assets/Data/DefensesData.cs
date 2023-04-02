using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Defenses Data", menuName = "Data/Defenses Data", order = 4)]
public class DefensesData : ScriptableObject
{
    public string _name;
    public int _buyPrice;
    public int _upgradePrice;
    public int _damage;
    public float _fireRate;
}