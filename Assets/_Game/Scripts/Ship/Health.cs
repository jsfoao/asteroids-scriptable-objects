using UnityEngine;
using Vars;

namespace Ship
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private IntRef health;
        
        private const int MIN_HEALTH = 0;
        
        public void TakeDamage(int damage)
        { 
            health.Set(Mathf.Max(MIN_HEALTH, health.Value - damage));
        }
    }
}
