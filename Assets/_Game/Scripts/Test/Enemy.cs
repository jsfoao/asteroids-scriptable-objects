using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int level; 
    
    public void LevelUp()
    {
        level++;
    }
}
