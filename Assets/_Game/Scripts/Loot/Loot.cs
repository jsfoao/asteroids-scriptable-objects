using System;
using UnityEngine;

public class Loot : MonoBehaviour
{
    [SerializeField] private LootType lootType;
    [NonSerialized] public Guid ID;

    private void Awake()
    {
        ID = Guid.NewGuid();
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
        if (ID != id)
        {
            return; 
        }
        Destroy(gameObject);
    }
}
