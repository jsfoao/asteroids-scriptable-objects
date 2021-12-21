using UnityEngine;

public class EventDebugger : MonoBehaviour
{
    public void DebugPickup(Pickup pickup)
    {
        Debug.Log($"{pickup}!");
    }
}