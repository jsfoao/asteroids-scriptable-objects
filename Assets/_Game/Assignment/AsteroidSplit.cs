using System;
using Asteroids;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSplit : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Asteroid asteroid;
    [SerializeField] private Asteroid asteroidPrefab;
    
    [Header("Split Settings")]
    [Tooltip("Minimum size for asteroid to be completely destroyed and not divided")]
    [SerializeField] private float minSize;
    [Tooltip("Higher number means more divisions for a certain size")]
    [SerializeField] private float divisionMultiplier;


    public void Split(Guid id)
    {
        if (asteroid.ID != id) { return; }

        if (asteroid.Size <= minSize)
        {
            Destroy(gameObject);
            return;
        }

        int divisions = Mathf.RoundToInt(asteroid.Size * divisionMultiplier);
        float baseSize = asteroid.Size / divisions;

        for (int i = 0; i < divisions; i++)
        {
            float newSize = Random.Range(baseSize - 0.05f, baseSize + 0.05f);
            var asteroid = Instantiate(asteroidPrefab, transform.position, Quaternion.identity);
            asteroid.SetSize(newSize);
        }
        Destroy(gameObject);
    }
}
