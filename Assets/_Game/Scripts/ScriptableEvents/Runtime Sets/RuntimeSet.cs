using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class RuntimeSet<T> : ScriptableObject
{
    public List<T> Items = new List<T>();
    public int Count => Items.Count;
    public T Last => Items[Items.Count - 1];

    public void Add(T t)
    {
        if (!Items.Contains(t))
        {
            Items.Add(t);
        }
    }

    public void Remove(T t)
    {
        if (Items.Contains(t))
        {
            Items.Remove(t);
        }
    }

    private void OnDisable()
    {
        Items.Clear();
    }

    private void OnEnable()
    {
        Items.Clear();
    }
}