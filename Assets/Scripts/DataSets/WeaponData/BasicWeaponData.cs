using UnityEngine;
using Asteroids.Weapon;

[CreateAssetMenu(fileName = "Basic Weapon Data", menuName = "Datasets/Basic Weapon Data", order = 1)]
public class BasicWeaponData : ScriptableObject
{
    public BulletCreator BulletCreator;
    public Bullet Bullet;
    public int CoolDownTime;
    public virtual Weapon GetWeapon() => new BasicWeapon(this);
}