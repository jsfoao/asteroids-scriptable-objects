using ScriptableEvents.Event;
using UnityEngine;
using Vars;

namespace Ship
{
    public class Hull : MonoBehaviour
    {
        [SerializeField] private ScriptableEventInt onCollisionAsteroid;
        [SerializeField] private ScriptableEventGuid onCollisionLoot;
        [SerializeField] private IntVar asteroidDamage;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (string.Equals(other.gameObject.tag, "Asteroid"))
            {
               onCollisionAsteroid.Raise(asteroidDamage.Value);
            }
            else if (string.Equals(other.gameObject.tag, "Loot"))
            {
                onCollisionLoot.Raise(other.gameObject.GetComponent<Loot>().ID);
            }
        }

        public void DestroyShip()
        {
            Destroy(gameObject);
        }
    }
}
