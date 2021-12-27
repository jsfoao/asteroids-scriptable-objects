using ScriptableEvents.Event;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableEvents.Listener
{
    public class ScriptableEventListener : MonoBehaviour
    {
        [SerializeField] protected bool debug;
        [SerializeField] private ScriptableEvent _eventNoPayload;
        [SerializeField] private UnityEvent _responseNoPayload;

        private void OnEventRaised()
        {
            _responseNoPayload.Invoke();

            if (debug) { DebugEvent(); }
        }

        private void OnEnable()
        {
            _eventNoPayload.Register(OnEventRaised);
        }

        private void OnDisable()
        {
            _eventNoPayload.Unregister(OnEventRaised);
        }

        private void DebugEvent()
        {
            Debug.Log($"Raised: {_eventNoPayload.name}");
            Debug.Log($"Data: None");
        }
    }
    
    public abstract class ScriptableEventListener<TPayload> : ScriptableEventListener
    {
        [SerializeField] private ScriptableEventBase<TPayload> _event;
        [SerializeField] private UnityEvent<TPayload> _response;

        private void OnEventRaised(TPayload payload)
        {
            _response.Invoke(payload);

            if (debug) { DebugEvent(payload); }
        }

        public void OnEnable()
        {
            _event.Register(OnEventRaised);
        }

        private void OnDisable()
        {
            _event.Unregister(OnEventRaised);
        }

        private void DebugEvent(TPayload payload)
        {
            Debug.Log($"Raised: {_event.name}");
            Debug.Log($"Data: {payload}");
        }
    }
}