using UnityEngine;

namespace Asteroids.Weapon
{
    public interface IBulletCreator
    {
        public Bullet CreateBullet(Vector2 position, Vector2 direction, Bullet bullet);
    }
}
