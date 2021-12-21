using ScriptableEvents.Runtime_Sets;
using UnityEditor.UI;
using UnityEngine;

public class DrawPoolGUI : MonoBehaviour
{
    [Header("Runtime Sets")]
    [SerializeField] private RuntimeSetGo setPooled;
    [SerializeField] private RuntimeSetGo setActive;
    
    [Header("GUI Settings")]
    [SerializeField] private Vector2 position;
    [SerializeField] private Vector2 size;
    [SerializeField] private float lineOffset;

    private void DrawLabel(string text, int line)
    {
        GUI.Label(new Rect(new Vector2(position.x, position.y +(lineOffset * line)), size), text);
    }
    private void OnGUI()
    {
        DrawLabel("Object Pool", 0);
        DrawLabel($"Pooled: {setPooled.Items.Count}", 1);
        DrawLabel($"Active: {setActive.Items.Count}", 2);
    }
}
