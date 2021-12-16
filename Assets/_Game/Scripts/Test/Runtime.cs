using ScriptableEvents.Event;
using UnityEngine;
using Vars;

public class Runtime : MonoBehaviour
{
    [SerializeField] private FloatRef healthRef;
    [SerializeField] private ScriptableEventFloatRef onHealthChangedEvent;

    public void TakeDamage(float damage)
    {
        healthRef.Set(healthRef.Value - damage);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            onHealthChangedEvent.Raise();
        }
    }
}
