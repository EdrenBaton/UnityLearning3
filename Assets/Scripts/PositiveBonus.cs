using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PositiveBonus : InteractableObject, IFlickable, IFlyable, IRotatable, IBonus
{
    [SerializeField] private float _flyDistance = 2.0f;
    [SerializeField] private float _rotationSpeed = 100.0f;
    [SerializeField] private int _bonus = 0;
    
    private Material _material;
    private float _startFlyPosition;
    
    public float FlyDistance => _flyDistance;
    public Material Material => _material;
    public float RotationSpeed => _rotationSpeed;
    public int Bonus => _bonus;
    
    protected override void Interact()
    {
        
    }

    public override void Initialize()
    {
        _bonus = _bonus == 0 ? Random.Range(1, 11) : _bonus;
        _startFlyPosition = transform.localPosition.x - transform.localScale.x;
        _material = GetComponent<Renderer>().material;
        _material.color = Random.ColorHSV();
    }
    public override void Execute()
    {
        Flick();
        Fly();
        Rotate();
    }

    public void Flick()
    {
        Material.color = new Color(Mathf.PingPong(Time.time, 1.0f),
            Material.color.g,
            Mathf.PingPong(Time.time, 1.0f),
            Material.color.a);
    }

    public void Fly()
    {
        transform.localPosition = new Vector3(Mathf.PingPong(Time.time, FlyDistance) + _startFlyPosition, 
            transform.localPosition.y,
            transform.localPosition.z);
    }

    public void Rotate()
    {
        transform.Rotate(Vector3.forward * (Time.deltaTime * RotationSpeed), Space.World);
    }
}