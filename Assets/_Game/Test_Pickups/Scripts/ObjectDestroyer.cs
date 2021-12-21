using ScriptableEvents.Runtime_Sets;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    [SerializeField] private RuntimeSetPickups runtimeSetPickups;

    public void DestroyPickup(Pickup pickup)
    {
        runtimeSetPickups.Remove(pickup);
        Destroy(pickup.gameObject);
    }
}
