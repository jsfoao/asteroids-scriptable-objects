using ScriptableEvents.Event;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private ScriptableEventBase<Pickup> onPickup;

    private void OnTriggerEnter(Collider other)
    {
        var pickup = other.GetComponent<Pickup>();
        if (pickup != null)
        {
            onPickup.Raise(pickup);
        }
    }
}
