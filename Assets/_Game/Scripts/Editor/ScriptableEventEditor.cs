using ScriptableEvents.Event;
using UnityEngine;

namespace _Game.Scripts.Editor
{
    using UnityEditor;

    [CustomEditor(typeof(ScriptableEventBase))]
    public class ScriptableEventFloatEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Debug Raise Event"))
            {
                Debug.Log($"Debug Raised {target.name}");
                ((ScriptableEventBase)target).Raise();
            }
        }
    }
    
    [CustomEditor(typeof(ScriptableEventFloatRef))]
    public class ScriptableEventFloatRefEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Debug Raise Event"))
            {
                Debug.Log($"Debug Raised {target.name}");
                ((ScriptableEventFloatRef)target).Raise();
            }
        }
    }
}