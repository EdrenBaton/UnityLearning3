using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerSetting", menuName = "CustomSettings/BonusSettings")]
public sealed class BonusData : ScriptableObject
{
    [SerializeField] private List<BonusInfo> _bonuses;

    [Serializable]
    public struct BonusInfo
    {
        public List<Vector3> Positions;
        public BonusType BonusType;
    }

    public List<BonusInfo> Bonuses => _bonuses;
}