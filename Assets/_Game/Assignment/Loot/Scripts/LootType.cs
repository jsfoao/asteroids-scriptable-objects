using UnityEngine;
using Vars;


[CreateAssetMenu(menuName = "Loot/LootType", fileName = "LootType", order = 0)]
public class LootType : ScriptableObject
{
    [Header("References")]
    [SerializeField] private FloatVar throttle;
    [SerializeField] private FloatVar rotation;
    [SerializeField] private IntVar health;
    [SerializeField] private BoolVar shotgunMode;
    
    [Header("Loot effects")]
    [SerializeField] private float throttleEffect;
    [SerializeField] private float rotationEffect;
    [SerializeField] private int healthEffect;
    [SerializeField] private bool shootEffect;
    
    public void OnPickup()
    {
        throttle.Set(throttle.Value + throttleEffect);
        rotation.Set(rotation.Value + rotationEffect);
        health.Set(health.Value + healthEffect);

        if (shotgunMode.Value) return;
        shotgunMode.Set(shootEffect);
    }
}
