using System;
using UnityEngine;

namespace Vars
{
    public class BaseVar<T> : ScriptableObject
    {
        [SerializeField] private T _value;
        [SerializeField] private T _currentValue;

        [TextArea(3, 6)] 
        [SerializeField] private string developerDescription;

        public T Value => _currentValue;

        public void Set(T value)
        {
            _currentValue = value;
        }

        private void OnEnable()
        {
            _currentValue = _value;
        }
    }
    
    [CreateAssetMenu(fileName = "new FloatVar", menuName = "Scriptable Object/Float Variable")]
    public class FloatVar : BaseVar<float> { }
}
