using UnityEngine;

public class PlayerBall : PlayerBase
{
    private Rigidbody _rigidbody;
    private Vector3 _movement;

    public override void Initialize()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public override void Move(float x, float y, float z)
    {
        _movement.Set(x, y, z);
        _rigidbody.AddForce(_movement * (_movementSpeed * _acceleration));
    }
}