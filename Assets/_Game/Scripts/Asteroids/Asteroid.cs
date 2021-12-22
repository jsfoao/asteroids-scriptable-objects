using System;
using System.Runtime.CompilerServices;
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

        private Rigidbody2D _rigidbody;
        private Vector3 _direction;
        [NonSerialized] public Guid ID;

        private void Awake()
        {
            ID = Guid.NewGuid();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void SetRandom()
        {
            SetRandomDirection();
            AddRandomForce();
            AddRandomTorque();
            SetRandomSize();
        }

        public void Set(float size, Vector3 direction)
        { 
            SetSize(size);
            SetDirection(direction);
            AddRandomForce();
        }

        #region Random
        private void SetRandomDirection()
        {
            var size = new Vector2(3f, 3f);
            var target = new Vector3
            (
                Random.Range(-size.x, size.x),
                Random.Range(-size.y, size.y)
            );

            _direction = (target - transform.position).normalized;
        }

        private void AddRandomForce()
        {
            var force = Random.Range(_minForce, _maxForce);
            _rigidbody.AddForce( _direction * force, ForceMode2D.Impulse);
        }

        private void AddRandomTorque()
        {
            var torque = Random.Range(_minTorque, _maxTorque);
            var roll = Random.Range(0, 2);

            if (roll == 0)
                torque = -torque;
            
            _rigidbody.AddTorque(torque, ForceMode2D.Impulse);
        }

        private void SetRandomSize()
        {
            Size = Random.Range(_minSize, _maxSize);
            _shape.localScale = new Vector3(Size, Size, 0f);
        }
        #endregion

        private void SetSize(float size)
        {
            Size = size;
            _shape.localScale = new Vector3(Size, Size, 0f);
        }

        private void SetDirection(Vector3 direction)
        {
            _direction = direction;
        }

        public void Destroy(Guid id)
        {
            if (id == ID)
            {
                Destroy(gameObject);
            }
        }
    }
}
