using UnityEngine;

public class ResourcesManager
{
    private PlayerBall _player;
    private bool _isPlayerCreated;
    
    private Camera _camera;
    private bool _isCameraCreated;

    public PlayerBall Player
    {
        get
        {
            if (_isPlayerCreated) return _player;
            
            _isPlayerCreated = true;
            _player = Object.Instantiate(Resources.Load<PlayerBall>("Player"));

            return _player;
        }
    }
    
    public Camera MainCamera
    {
        get
        {
            if (_isCameraCreated) return _camera;
            
            _isCameraCreated = true;
            _camera = Camera.main;

            return _camera;
        }
    }
}