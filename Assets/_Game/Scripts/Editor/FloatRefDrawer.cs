using UnityEditor;
using UnityEngine;
using Vars;

[CustomPropertyDrawer(typeof(FloatRef))]
public class FloatRefDrawer : PropertyDrawer
{
    // EditorGUI
    // EditorGUILayout
    // GUI
    // GUILayout
    // Layout: Handles layout automatically
    // Editor: Only used in editor
    // Not "Editor": In game + editor
    // Handles: Scene view stuff
    
    private readonly string[] popupOptions = {"Use Constant", "Use Variable"};

    private GUIStyle popupStyle;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // TODO what is begin and end property for???
        EditorGUI.BeginProperty(position, label, property);
        
        position = EditorGUI.PrefixLabel(position, label);
        
        // Get properties
        var useSimpleValueProperty = property.FindPropertyRelative(FloatRef.UseSimpleValue);
        var variableProperty = property.FindPropertyRelative(FloatRef.Variable);
        var simpleValueProperty = property.FindPropertyRelative(FloatRef.SimpleValue);

        // Draw button
        // Create style
        popupStyle ??= new GUIStyle(GUI.skin.GetStyle("PaneOptions"))
        {
            imagePosition = ImagePosition.ImageOnly
        };

        // Calculate button rect
        var buttonRect = new Rect(position);
        buttonRect.yMin += popupStyle.margin.top;
        buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right;
        
        position.xMin = buttonRect.xMax;

        // Popup selection
        var selectedIndex = useSimpleValueProperty.boolValue ? 0 : 1;
        var result = EditorGUI.Popup(buttonRect, selectedIndex, popupOptions, popupStyle);
        useSimpleValueProperty.boolValue = result == 0;

        EditorGUI.PropertyField(
            position, 
            selectedIndex == 0 ? simpleValueProperty : variableProperty, 
            GUIContent.none);

        EditorGUI.EndProperty();
    }
}
