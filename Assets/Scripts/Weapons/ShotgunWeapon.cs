using UnityEngine;
using Asteroids.Weapon;
using Asteroids.Utilities;
using Asteroids;

public class ShotgunWeapon : Weapon
{
    private float _spread;
    private int _bulletsPerShot;
    public ShotgunWeapon(ShotgunWeaponData weaponData)
    {
        _bulletCreator = weaponData.BulletCreator;
        _bullet = weaponData.Bullet;
        _coolDown = new CoolDown(weaponData.CoolDownTime);
        _spread = weaponData.Spread;
        _bulletsPerShot = weaponData.BulletsPerShot;
    }
    protected override void OnShot(Vector2 origin, Vector2 direction)
    {
        float yDirectionSign = direction.y / Mathf.Abs(direction.y);
        float spreadAngle = (Mathf.Acos(direction.x / Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y)) / (6.28f / 360f) * yDirectionSign) - (_spread / 2f);
        for (int i = 0; i < _bulletsPerShot; i++)
        {
            direction = new Vector2(Mathf.Cos(spreadAngle * (6.28f / 360f)), Mathf.Sin(spreadAngle * (6.28f / 360f)));
            spreadAngle = spreadAngle + (_spread / (_bulletsPerShot - 1));
            Bullet bullet = _bulletCreator.CreateBullet(origin, direction, _bullet);
            bullet.Attack<Enemy>();
        }
    }
}
