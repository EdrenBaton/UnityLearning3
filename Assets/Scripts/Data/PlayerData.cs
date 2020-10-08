using UnityEngine;


[CreateAssetMenu(fileName = "PlayerSetting", menuName = "CustomSettings/PlayerSettings")]
public sealed class PlayerData : ScriptableObject
{
    [SerializeField, Range(1, 10)] private float _playerSpeed;
}