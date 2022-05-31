using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids.Weapon;
using Asteroids;
using Asteroids.Utilities;

public class BasicWeapon : Weapon
{
    public BasicWeapon(BasicWeaponData weaponData)
    {
        _bulletCreator = weaponData.BulletCreator;
        _bullet = weaponData.Bullet;
        _coolDown = new CoolDown(weaponData.CoolDownTime);
    }
    protected override void OnShot(Vector2 origin, Vector2 direction)
    {
        Bullet bullet = _bulletCreator.CreateBullet(origin, direction, _bullet);
        bullet.Attack<Enemy>();
    }
}