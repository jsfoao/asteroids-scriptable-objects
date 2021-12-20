using ScriptableEvents.Event;
using UnityEngine;

public class MyMono : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private bool selected;
    [SerializeField] private ScriptableEvent _myEvent;
    
    public void AddHealth()
    {
        if (!selected) { return; }
        health++;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _myEvent.Raise();
        }
    }
}
