using ScriptableEvents.Event;
using UnityEngine;

namespace Ship
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Laser _laserPrefab;
        [SerializeField] private ScriptableEvent onShootEvent;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                onShootEvent.Raise();
            }
        }
        
        public void Shoot()
        {
            var trans = transform;
            Instantiate(_laserPrefab, trans.position, trans.rotation);
        }
    }
}
