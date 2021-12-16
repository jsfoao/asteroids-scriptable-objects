using ScriptableEvents.Event;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableEvents
{
    public abstract class ScriptableEventListenerBase<TPayload> : MonoBehaviour
    {
        [SerializeField] protected ScriptableEventBase<TPayload> _event;
        [SerializeField] protected UnityEvent<TPayload> response;

        public virtual void OnEventRaised(TPayload payload)
        {
            response.Invoke(payload);
        }
        
        private void OnEnable()
        {
            _event.Register(OnEventRaised);
        }

        private void OnDisable()
        {
            _event.Unregister(OnEventRaised);
        }
    }
}