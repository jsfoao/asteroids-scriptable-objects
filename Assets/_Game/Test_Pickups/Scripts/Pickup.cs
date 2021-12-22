using ScriptableEvents.Runtime_Sets;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private RuntimeSetPickup runtimeSetPickup;
    
    
    private void OnEnable()
    {
        runtimeSetPickup.Add(this);
    }
}
