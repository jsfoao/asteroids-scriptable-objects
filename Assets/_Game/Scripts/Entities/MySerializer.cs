using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class MySerializer : MonoBehaviour
{
    [SerializeField] private Element _element;

    private const string KEY = "MY_TEST_KEY";
    
    [ContextMenu("Save")]
    public void SaveToDisk()
    {
        var jsonString = JsonUtility.ToJson(_element);
        
        PlayerPrefs.SetString(KEY, jsonString);
        PlayerPrefs.Save();
    }

    [ContextMenu("Load")]
    public void LoadFromDisk()
    {
        var savedJson = PlayerPrefs.GetString(KEY);
        JsonUtility.FromJsonOverwrite(savedJson, _element);
    }

    [ContextMenu("Load and Save")]
    public void LoadFromDiskAndSaveAsset()
    {
        var savedJson = PlayerPrefs.GetString(KEY);
        var newElement = ScriptableObject.CreateInstance<Element>();
        JsonUtility.FromJsonOverwrite(savedJson, newElement);
        
        // AssetDatabase.Contains()
        var path = "Assets/_Game/Test_Elements/Elements/ElementFromDisk.asset";
        // var asset = AssetDatabase.LoadAssetAtPath(savedJson, newElement);

    }
}