using Asteroids;
using UnityEngine;

namespace ScriptableEvents.Runtime_Sets
{
    [CreateAssetMenu(menuName = "Runtime Set/Asteroid", fileName = "RuntimeSetAsteroid", order = 0)]
    class RuntimeSetAsteroids : RuntimeSet<Asteroid> { }
}