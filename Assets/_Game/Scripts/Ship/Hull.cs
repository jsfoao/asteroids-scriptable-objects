using ScriptableEvents.Event;
using UnityEngine;
using Vars;

namespace Ship
{
    public class Hull : MonoBehaviour
    {
        [SerializeField] private ScriptableEventInt onCollisionAsteroid;
        [SerializeField] private IntVar asteroidDamage;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (string.Equals(other.gameObject.tag, "Asteroid"))
            {
               onCollisionAsteroid.Raise(asteroidDamage.Value);
            }
        }

        public void DestroyShip()
        {
            Destroy(gameObject);
        }
    }
}
