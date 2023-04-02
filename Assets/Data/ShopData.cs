using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopData", menuName = "Data/Shop/ShopData", order = 0)]
public class ShopData : ScriptableObject
{
    public List<DefensesData> _itemDataList;
}
