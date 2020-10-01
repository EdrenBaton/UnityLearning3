using UnityEngine;

public class NegativeBonus : InteractableObject, IFlickable, IFlyable, IRotatable, IBonus
{
    [SerializeField] private float _flyDistance = 1.0f;
    [SerializeField] private float _rotationSpeed = 10.0f;
    [SerializeField] private int _bonus = 0;
    
    private Material _material;
    private float _startFlyPosition;
    
    public float FlyDistance => _flyDistance;
    public Material Material => _material;
    public float RotationSpeed => _rotationSpeed;    
    public int Bonus => _bonus;

    public override void Initialize()
    {
        _bonus = _bonus == 0 ? Random.Range(1, 11) : _bonus;
        _startFlyPosition = transform.localPosition.y;
        _material = GetComponent<Renderer>().material;
        _material.color = Random.ColorHSV();
    }

    protected override void Interact()
    {
        
    }

    public override void Execute()
    {
        Flick();
        Fly();
        Rotate();
    }

    public void Flick()
    {
        Material.color = new Color(Material.color.r,
            Material.color.g,
            Material.color.b,
            Mathf.PingPong(Time.time, 1.0f));
    }

    public void Fly()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, 
            Mathf.PingPong(Time.time, FlyDistance) + _startFlyPosition,
            transform.localPosition.z);
    }

    public void Rotate()
    {
        transform.Rotate(Vector3.up * (Time.deltaTime * RotationSpeed), Space.World);
    }
}