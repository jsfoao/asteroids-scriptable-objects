using UnityEngine;

namespace Test_Pickups.Scripts
{
    [CreateAssetMenu(menuName = "Test/Pickup", fileName = "Pickup", order = 0)]
    public class PickupStats : ScriptableObject
    {
        [SerializeField] public Player Player;
        [Range(0, 10)]
        [SerializeField] public int Health;
        [Range(0, 10)]
        [SerializeField] public int Strength;
        [Range(0, 10)]
        [SerializeField] public int Speed;
    }
}
