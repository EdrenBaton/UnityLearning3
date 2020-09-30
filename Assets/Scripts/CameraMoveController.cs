using UnityEngine;

public class CameraMoveController : MyGameObject
{
    private PlayerMoveController _player;
    
    private Vector3 _offset;

    public void SetPosition()
    {
        transform.position = _player.transform.position + _offset;
    }

    public override void Initialize()
    {
        _player = FindObjectOfType<PlayerMoveController>();
        _offset = transform.position - _player.transform.position;
    }
}