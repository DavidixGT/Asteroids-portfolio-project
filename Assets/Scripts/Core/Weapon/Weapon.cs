using System.Threading.Tasks;
using UnityEngine;
using Asteroids.Utilities;

namespace Asteroids.Weapon
{
    public abstract class Weapon
    {
        protected IBulletCreator _bulletCreator;
        protected Bullet _bullet;
        protected CoolDown _coolDown;
        private bool _isReloaded => _coolDown.IsCompleted;

        public async Task Shoot(Vector2 origin, Vector2 direction)
        {
            if (_isReloaded)
            {
                await Reload();
                OnShot(origin, direction);
            }
        }
        private async Task Reload() => await _coolDown.StartCoolDown();
        protected abstract void OnShot(Vector2 origin, Vector2 direction);
    }
}
