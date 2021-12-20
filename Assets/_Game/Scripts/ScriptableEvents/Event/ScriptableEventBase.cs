using System;
using UnityEngine;

namespace ScriptableEvents.Event
{
    /// <summary>
    /// _eventNoPayload is event without payload, without any data
    /// To raise events that don't take any data:
    /// Playing sound, vfx, etc
    /// </summary>
    public abstract class ScriptableEventBase : ScriptableObject
    {
        private event Action _eventNoPayload;
    
        public void Register(Action onEventNoPayload)
        {
            _eventNoPayload += onEventNoPayload;
        }

        public void Unregister(Action onEventNoPayload)
        {
            _eventNoPayload -= onEventNoPayload;
        }

        public void Raise()
        {
            _eventNoPayload?.Invoke();
        }
    }

    /// <summary>
    /// Action: Encapsulates a method that has a single parameter and does not return a value.
    /// For health for example, we want to pass in int/float data
    /// </summary>
    public abstract class ScriptableEventBase<TPayload> : ScriptableEventBase
    {
        private event Action<TPayload> _event;

        public void Register(Action<TPayload> onEvent)
        {
            _event += onEvent;
        }

        public void Unregister(Action<TPayload> onEvent)
        {
            _event -= onEvent;
        }

        public void Raise(TPayload payload)
        {
            _event?.Invoke(payload);
        }
    }
}