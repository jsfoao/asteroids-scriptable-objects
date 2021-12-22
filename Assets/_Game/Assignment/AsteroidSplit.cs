using System;
using Asteroids;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSplit : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Asteroid asteroid;
    [SerializeField] private Asteroid asteroidPrefab;
    private Rigidbody2D _rigidbody2D;
    
    [Header("Split Settings")]
    [SerializeField] private int minDivision;
    [SerializeField] private int maxDivision;
    [SerializeField] private float minSize;
    
    
    public void Split(Guid id)
    {
        if (asteroid.ID != id) { return; }

        if (asteroid.Size <= minSize)
        {
            Destroy(gameObject);
            return;
        }
        
        int divisions = Random.Range(minDivision, maxDivision + 1);
        float baseSize = asteroid.Size / divisions;

        for (int i = 0; i < divisions; i++)
        {
            float newSize = Random.Range(baseSize - 0.1f, baseSize + 0.1f);
            Spawn(transform.position, newSize);
        }
        Destroy(gameObject);
    }

    private void Spawn(Vector3 location, float size)
    {
        var asteroid = Instantiate(asteroidPrefab, location, Quaternion.identity);
        
        Vector2 currentVelocity = _rigidbody2D.velocity.normalized;
        Vector2 randomDirection = GetRandomDirection();
        Vector2 direction = (currentVelocity + randomDirection).normalized;
        asteroid.Set(size, direction);
    }

    private Vector2 GetRandomDirection()
    {
        var size = new Vector2(3f, 3f);
        var target = new Vector3
        (
            Random.Range(-size.x, size.x),
            Random.Range(-size.y, size.y)
        );

        return (target - transform.position).normalized;
    }
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
}
