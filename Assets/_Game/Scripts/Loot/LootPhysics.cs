using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootPhysics : MonoBehaviour
{
    [Header("Config:")]
    [SerializeField] private float _minForce;
    [SerializeField] private float _maxForce;
    [SerializeField] private float _minTorque;
    [SerializeField] private float _maxTorque;

    private Vector3 _direction;
    private Rigidbody2D _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
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
}
