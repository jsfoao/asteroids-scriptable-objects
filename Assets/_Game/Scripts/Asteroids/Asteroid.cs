using System;
using System.Runtime.CompilerServices;
using ScriptableEvents.Runtime_Sets;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Asteroid : MonoBehaviour
    {
        public float Size;

        [Header("Config:")]
        [SerializeField] private float _minForce;
        [SerializeField] private float _maxForce;
        [SerializeField] private float _minSize;
        [SerializeField] private float _maxSize;
        [SerializeField] private float _minTorque;
        [SerializeField] private float _maxTorque;

        [Header("References:")]
        [SerializeField] private Transform _shape;
        [SerializeField] private RuntimeSetAsteroids _runtimeSetAsteroids;

        private Rigidbody2D _rigidbody;
        private Vector3 _direction;
        [NonSerialized] public Guid ID;

        private void Awake()
        {
            ID = Guid.NewGuid();
            _rigidbody = GetComponent<Rigidbody2D>();
            _runtimeSetAsteroids.Add(this);
        }

        private void Start()
        {
            SetPhysics();
        }

        public void SetPhysics()
        {
            SetDirection();
            AddForce();
            AddTorque();
        }

        private void SetDirection()
        {
            var size = new Vector2(3f, 3f);
            var target = new Vector3
            (
                Random.Range(-size.x, size.x),
                Random.Range(-size.y, size.y)
            );

            _direction = (target - transform.position).normalized;
        }

        private void AddForce()
        {
            var force = Random.Range(_minForce, _maxForce);
            _rigidbody.AddForce( _direction * force, ForceMode2D.Impulse);
        }

        private void AddTorque()
        {
            var torque = Random.Range(_minTorque, _maxTorque);
            var roll = Random.Range(0, 2);

            if (roll == 0)
                torque = -torque;
            
            _rigidbody.AddTorque(torque, ForceMode2D.Impulse);
        }

        public void SetRandomSize()
        {
            Size = Random.Range(_minSize, _maxSize);
            _shape.localScale = new Vector3(Size, Size, 0f);
        }

        public void SetSize(float size)
        {
            Size = size;
            _shape.localScale = new Vector3(Size, Size, 0f);
        }

        public void Destroy(Guid id)
        {
            if (id == ID)
            {
                Destroy(gameObject);
            }
        }

        public void OnDestroy()
        {
            _runtimeSetAsteroids.Remove(this);
        }
    }
}
