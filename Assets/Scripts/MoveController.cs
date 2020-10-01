using UnityEngine;

public class MoveController : IExecutable
{
    private readonly IMovable _player;

    public MoveController(IMovable player)
    {
        _player = player;
    }
    
    public void Execute()
    {
        var moveRight = Input.GetAxis("Horizontal");
        var moveForward = Input.GetAxis("Vertical");
        var moveVertical = 0.0f;
        
        _player.Move(moveRight, moveVertical, moveForward);
    }
}