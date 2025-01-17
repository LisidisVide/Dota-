using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/BarracksData")]
public class BarracksData : ScriptableObject
{
    [Header("Spawn wait?")]
    public bool IsWait;

    [Header("Wave")]
    public SpawnerData SpawnerData;

    [Header("StructData")]
    public DataStructure DataStructure;

    [Header("UnitPrefab")]
    public List<PrefabUnit> Prefabs = new List<PrefabUnit>();
}

[System.Serializable]
public class PrefabUnit
{
    public TypeUnit TypeUnit;
    public Unit Prefab;
}
