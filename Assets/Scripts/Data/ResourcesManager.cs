using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

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

    public InteractableObject CreateInteractableObject(BonusType bonusType, Vector3 position)
    {
        switch (bonusType)
        {
            case BonusType.NegativeBonus:
                return CreateNegativeBonus(position);
            case BonusType.PositiveBonus:
                return CreatePositiveBonus(position);
            default:
                throw new ArgumentOutOfRangeException(nameof(bonusType), bonusType, null);
        }
    }

    private static PositiveBonus CreatePositiveBonus(Vector3 position) => Object.Instantiate(Resources.Load<PositiveBonus>("PositiveBonus"), position, Quaternion.identity);
    
    private static NegativeBonus CreateNegativeBonus(Vector3 position) => Object.Instantiate(Resources.Load<NegativeBonus>("NegativeBonus"), position, Quaternion.identity);
}