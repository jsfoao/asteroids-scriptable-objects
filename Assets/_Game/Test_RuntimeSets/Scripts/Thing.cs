using ScriptableEvents.Runtime_Sets;
using UnityEngine;

public class Thing : MonoBehaviour
{
    [SerializeField] private RuntimeSetThing runtimeSet;

    private void Start()
    {
        runtimeSet.Add(this);
    }
}
