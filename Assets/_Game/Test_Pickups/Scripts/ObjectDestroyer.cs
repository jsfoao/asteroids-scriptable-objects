using ScriptableEvents.Runtime_Sets;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    [SerializeField] private RuntimeSetPickup runtimeSetPickup;

    public void DestroyPickup(Pickup pickup)
    {
        runtimeSetPickup.Remove(pickup);
        Destroy(pickup.gameObject);
    }
}
