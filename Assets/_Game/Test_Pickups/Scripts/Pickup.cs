using ScriptableEvents.Runtime_Sets;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private RuntimeSetPickups runtimeSetPickups;
    
    
    private void OnEnable()
    {
        runtimeSetPickups.Add(this);
    }
}
