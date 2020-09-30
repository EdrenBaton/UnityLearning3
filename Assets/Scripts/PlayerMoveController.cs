using UnityEngine;

public class PlayerMoveController : MoveController
{
    private Rigidbody _rigidbody;

    public override void Move()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
            
        var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            
        _rigidbody.AddForce(movement * (_movementSpeed * _acceleration));
    }

    public override void Initialize()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
}