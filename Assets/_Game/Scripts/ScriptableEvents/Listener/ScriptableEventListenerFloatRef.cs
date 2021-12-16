using UnityEngine;
using Vars;

namespace ScriptableEvents
{
    public class ScriptableEventListenerFloatRef : ScriptableEventListenerBase<FloatRef>
    {
        public override void OnEventRaised(FloatRef payload)
        {
            base.OnEventRaised(payload);
            Debug.Log($"OnEventRaise: {payload.Value}");
        }
    }
}