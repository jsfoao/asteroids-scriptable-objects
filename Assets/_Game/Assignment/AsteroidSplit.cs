using System;
using Asteroids;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSplit : MonoBehaviour
{
    [Header("References")]
    private Asteroid _asteroid;
    [SerializeField] private Asteroid asteroidPrefab;
    
    [Header("Split Settings")]
    [Tooltip("Minimum size for asteroid to be completely destroyed and not divided")]
    [SerializeField] private float minSize;
    [Tooltip("Higher number means more divisions for a certain size")]
    [SerializeField] private float divisionMultiplier;


    public void Split(Guid id)
    {
        if (_asteroid.ID != id) { return; }

        if (_asteroid.Size <= minSize)
        {
            _asteroid.Destroy(id);
            return;
        }

        int divisions = Mathf.RoundToInt(_asteroid.Size * divisionMultiplier);
        float baseSize = _asteroid.Size / divisions;

        for (int i = 0; i < divisions; i++)
        {
            float newSize = Random.Range(baseSize - 0.05f, baseSize + 0.05f);
            var asteroid = Instantiate(asteroidPrefab, transform.position, Quaternion.identity);
            asteroid.SetSize(newSize);
        }
        _asteroid.Destroy(id);
    }

    private void Start()
    {
        _asteroid = GetComponent<Asteroid>();
    }
}
