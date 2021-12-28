using System;
using ScriptableEvents.Runtime_Sets;
using UnityEngine;

public class Loot : MonoBehaviour
{
    [SerializeField] private LootType lootType;
    [SerializeField] private RuntimeSetGo runtimeSetLoot;
    [NonSerialized] public Guid ID;

    private void Awake()
    {
        ID = Guid.NewGuid();
        runtimeSetLoot.Add(gameObject);
    }

    public void OnPickup(Guid id)
    {
        if (ID != id)
        {
            return; 
        }
        lootType.OnPickup();
    }

    public void Destroy(Guid id)
    {
        if (ID != id) return;
        runtimeSetLoot.Remove(gameObject);
        Destroy(gameObject);
    }

    public void Destroy()
    {
        runtimeSetLoot.Remove(gameObject);
        Destroy(gameObject);
    }
}
