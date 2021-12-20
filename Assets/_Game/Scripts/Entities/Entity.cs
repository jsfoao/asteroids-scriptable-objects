using TMPro;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] public Element element;
    [SerializeField] private TextMeshProUGUI label;
    private void OnTriggerEnter(Collider other)
    {
        Entity otherEntity = other.gameObject.GetComponent<Entity>();
        foreach (Element element in element.DefeatedElements)
        {
            if (otherEntity.element == element)
            {
                Debug.Log($"Destroy {otherEntity.element}");
                Destroy(otherEntity.gameObject);
            }
        }
    }

    private void Start()
    {
        label.text = element.name;
    }
}
