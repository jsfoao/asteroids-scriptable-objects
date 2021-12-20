using ScriptableEvents.Event;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableEvents.Listener
{
    public class ScriptableEventListener : MonoBehaviour
    {
        [SerializeField] private ScriptableEvent _eventNoPayload;
        [SerializeField] private UnityEvent _responseNoPayload;

        private void OnEventRaised()
        {
            _responseNoPayload.Invoke();
        }

        private void OnEnable()
        {
            _eventNoPayload.Register(OnEventRaised);
        }

        private void OnDisable()
        {
            _eventNoPayload.Unregister(OnEventRaised);
        }
    }
    
    public abstract class ScriptableEventListener<TPayload> : ScriptableEventListener
    {
        [SerializeField] private ScriptableEventBase<TPayload> _event;
        [SerializeField] private UnityEvent<TPayload> _response;

        private void OnEventRaised(TPayload payload)
        {
            _response.Invoke(payload);
        }

        public void OnEnable()
        {
            _event.Register(OnEventRaised);
        }

        private void OnDisable()
        {
            _event.Unregister(OnEventRaised);
        }
    }
}