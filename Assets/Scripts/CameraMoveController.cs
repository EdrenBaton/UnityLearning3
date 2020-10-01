using UnityEngine;

public class CameraMoveController : IExecutable
{
    private readonly PlayerBase _player;
    private readonly Camera _camera;
    private readonly Vector3 _offset;

    private readonly float _xOffset = 0.0f;
    private readonly float _yOffset = 5.0f;
    private readonly float _zOffset = -5.0f;

    public CameraMoveController(PlayerBase player, Camera camera)
    {
        _player = player;
        _camera = camera;
        _camera.transform.LookAt(_player.transform);
        _offset.Set(_xOffset, _yOffset, _zOffset);
    }

    public void Execute()
    {
        _camera.transform.position = _player.transform.position + _offset;
    }
}