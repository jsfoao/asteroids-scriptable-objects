using ScriptableEvents.Event;
using UnityEngine;
using Vars;

namespace Ship
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Laser _laserPrefab;
        [SerializeField] private ScriptableEvent onShootEvent;
        [SerializeField] public BoolRef shotgunMode;
        [SerializeField] public IntVar lasersShot;

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
            lasersShot.Set(lasersShot.Value + 1);
            
            if (!shotgunMode.Value) return;
            Instantiate(_laserPrefab, trans.position, trans.rotation * Quaternion.Euler(0, 0, 45));
            Instantiate(_laserPrefab, trans.position, trans.rotation * Quaternion.Euler(0, 0, -45));
            lasersShot.Set(lasersShot.Value + 2);
        }
    }
}
