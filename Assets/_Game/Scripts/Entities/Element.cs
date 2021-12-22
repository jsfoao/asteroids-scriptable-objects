using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Element", menuName = "Test/Element")]
public class Element : ScriptableObject
{
    [Tooltip("Elements defeated by this element")]
    [SerializeField] public List<Element> DefeatedElements;
}