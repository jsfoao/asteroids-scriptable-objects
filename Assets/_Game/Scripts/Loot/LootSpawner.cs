using UnityEngine;

public class LootSpawner : MonoBehaviour
{
    [SerializeField] private GameObject lootPrefab;
    [Range(0f, 1f)] [Tooltip("Chance of dropping loot when destroying asteroid")]
    [SerializeField] private float lootChance;
    
    public void DropLoot(Vector3 location)
    {
        Debug.Log("Drop loot");
        float chance = Random.Range(0, 1f);
        if (chance > lootChance) { return; } 
        Instantiate(lootPrefab, location, Quaternion.identity);
    }
}
