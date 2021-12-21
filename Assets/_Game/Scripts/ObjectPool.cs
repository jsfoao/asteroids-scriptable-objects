using System;
using ScriptableEvents.Runtime_Sets;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [NonSerialized] public static ObjectPool Instance;
    
    [Header("Runtime Sets")]  
    [SerializeField] private RuntimeSetGo setPooled;
    [SerializeField] private RuntimeSetGo setActive;

    [Header("Pooling")]
    public GameObject objectPrefab;
    public int amountToPool;

    private void Setup()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject go = Instantiate(objectPrefab);
            go.SetActive(false);
            setPooled.Add(go);
        }
    }

    public GameObject Create()
    {
        if (setPooled.Items.Count == 0) { return null; }
        
        GameObject objectToSpawn = setPooled.Last;
        if (objectToSpawn != null)
        {
            objectToSpawn.SetActive(true);
            
            setPooled.Remove(objectToSpawn);
            setActive.Add(objectToSpawn);
            
            return objectToSpawn;
        }

        return null;
    }

    public void Return(GameObject go)
    {
        if (setActive.Count == 0) { return; }
        
        go.SetActive(false);
        
        setActive.Remove(go);
        setPooled.Add(go);
    }

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(this); }
        
        Setup();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Create();
        }

        // if (Input.GetKeyDown(KeyCode.A))
        // {
        //     Return(_activeObjects.Dequeue());
        // }
    }
}

