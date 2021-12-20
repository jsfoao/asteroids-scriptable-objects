using ScriptableEvents.Event;
using TMPro;
using UnityEngine;
using Vars;

public class Entity : MonoBehaviour
{
    [SerializeField] public Element element;
    [SerializeField] private TextMeshProUGUI label;

    [SerializeField] private ScriptableEventInt onHitEvent;
    [SerializeField] private ScriptableEventInt onKillEvent;
    

    [SerializeField] private int destroyedElements;
    
    private void OnTriggerEnter(Collider other)
    {
        Entity otherEntity = other.gameObject.GetComponent<Entity>();
        foreach (Element element in element.DefeatedElements)
        {
            if (otherEntity.element == element)
            {
                int otherID = otherEntity.GetInstanceID();
                int thisID = GetInstanceID();
                onHitEvent.Raise(otherID);
                onKillEvent.Raise(thisID);
            }
        }
    }

    public void OnKillEntity(int entityID)
    {
        int id = GetInstanceID();
        if (id == entityID)
        {
            destroyedElements++;
        }
    }

    public void OnHitByEntity(int entityID)
    {
        int id = GetInstanceID();
        if (id == entityID)
        {
            Destroy(gameObject);
        }
    }

    public void DebugDestroy(int entityID)
    {
        int id = GetInstanceID();
        if (id == entityID)
        {
            Debug.Log($"{element} was destroyed!");
        }
    }

    public void CalledEvent()
    {
        Debug.Log("Called");
    }

    public void AddDestroyedElements()
    {
        destroyedElements++;
    }

    private void Start()
    {
        label.text = element.name;
    }
}
