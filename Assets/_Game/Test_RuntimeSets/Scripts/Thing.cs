using ScriptableEvents.Runtime_Sets;
using UnityEngine;

public class Thing : MonoBehaviour
{
    [SerializeField] private RuntimeSetThings runtimeSet;

    private void Start()
    {
        runtimeSet.Add(this);
    }
}
