using System;
using UnityEngine;

public abstract class PlayerBase : BaseGameObject, IMovable
{
    [SerializeField] protected float _movementSpeed = 3.0f;
    [SerializeField] protected float _acceleration = 1.0f;

    private void Start()
    {
        if (_movementSpeed <= 0.0f)
        {
            throw new MyException("Скорость объекта должна быть больше 0");
        }
        if (_acceleration <= 0.0f)
        {
            throw new MyException("Ускорение объекта должна быть больше 0");
        }
    }

    public abstract void Move(float x, float y, float z);
}