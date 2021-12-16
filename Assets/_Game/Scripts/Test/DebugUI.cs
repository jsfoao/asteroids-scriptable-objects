using UnityEngine;
using Vars;

public class DebugUI : MonoBehaviour
{
    public void PrintHealth(FloatRef health)
    {
        Debug.Log($"Print Health: {health.Value}");
    }
}
