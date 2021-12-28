using System;
using System.Collections.Generic;
using ScriptableEvents.Runtime_Sets;
using UnityEngine;
using Random = UnityEngine.Random;

public class LootSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> lootPrefabs;
    [Range(0f, 1f)] [Tooltip("Chance of dropping loot when destroying asteroid")]
    [SerializeField] private float lootChance;
    [SerializeField] private RuntimeSetGo runtimeSetLoot;
    
    public void DropLoot(Vector3 location)
    {
        if (lootPrefabs.Count == 0) { return; }
        
        float chance = Random.Range(0, 1f);
        if (chance > lootChance) { return; }
        
        int index = Random.Range(0, lootPrefabs.Count);
        Instantiate(lootPrefabs[index], location, Quaternion.identity);
    }
}
