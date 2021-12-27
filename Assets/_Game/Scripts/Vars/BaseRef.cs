using System;
using UnityEngine;

namespace Vars
{
    [Serializable]
    public abstract class BaseRef<T>
    {
        #region Properties
        public static string Variable => nameof(variable);
        public static string UseSimpleValue => nameof(useSimpleValue);
        public static  string SimpleValue => nameof(simpleValue);
        #endregion
        
        [Tooltip("Mono value / Scriptable Object value")] 
        [SerializeField] protected bool useSimpleValue;
        [SerializeField] protected BaseVar<T> variable; 
        [SerializeField] protected T simpleValue;

        public T Value => useSimpleValue ? simpleValue : variable.Value;

        public void Set(T value)
        {
            variable.Set(value);
        }
    }

    [Serializable]
    public class FloatRef : BaseRef<float> { }
    
    [Serializable]
    public class IntRef : BaseRef<int> { }
    
    [Serializable]
    public class BoolRef : BaseRef<bool> { }
}