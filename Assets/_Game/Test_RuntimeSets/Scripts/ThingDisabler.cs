using ScriptableEvents.Event;
using ScriptableEvents.Runtime_Sets;
using UnityEngine;
using Random = UnityEngine.Random;

public class ThingDisabler : MonoBehaviour
{
    [SerializeField] private ScriptableEvent disableEvent;
    [SerializeField] private RuntimeSetThings runtimeSet;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            disableEvent.Raise();
        }
    }

    public void DisableRandom()
    {
        int randomIndex = Random.Range(0, runtimeSet.Items.Count - 1);
        Thing thing = runtimeSet.Items[randomIndex];
        runtimeSet.Remove(thing);
        Destroy(thing);
    }

    private void Destroy(Thing thing)
    {
        Destroy(thing.gameObject);
    }
}
