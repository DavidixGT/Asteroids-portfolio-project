using UnityEngine;
using Asteroids.Movement;

[System.Serializable]
public class PlayerData
{
    public BasicWeaponData WeaponData => _weaponData;
    [SerializeField]
    private BasicWeaponData _weaponData;
    public SpeedCurve SpeedCurve => _speedCurve;
    [SerializeField]
    private SpeedCurve _speedCurve;
    public float RotationSpeed => _rotationSpeed;
    [SerializeField]
    private float _rotationSpeed;
}