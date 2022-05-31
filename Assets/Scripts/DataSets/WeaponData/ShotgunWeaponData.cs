using UnityEngine;
using Asteroids.Weapon;

[CreateAssetMenu(fileName = "Shotgun Weapon Data", menuName = "Datasets/Shotgun Weapon Data", order = 1)]
public class ShotgunWeaponData : BasicWeaponData
{
    [Range(0f, 360f)]
    public float Spread;
    public int BulletsPerShot;
    public override Weapon GetWeapon() => new ShotgunWeapon(this);
}