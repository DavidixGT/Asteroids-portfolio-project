using System;
using UnityEngine;
using Asteroids.Utilities;

namespace Asteroids.Weapon
{
    public abstract class Bullet : GameBehaviour
    {
        [SerializeField]
        private float _lifeTime;
        protected Type _typeOfEntityToAttack;
        [SerializeField]
        protected float _damage;
        private LifeTimeTimer _lifeTimeTimer;
        public event Action<IDamageable> HitDamageable;
        public virtual void Initialize(Vector2 position, Vector2 direction)
        {
            _lifeTimeTimer = new LifeTimeTimer(this, _lifeTime);
            transform.position = position;
            float bulletRotation = (Mathf.Abs(direction.y) / direction.y) * Mathf.Acos(direction.x / Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y)) / (6.28f / 360f) - 90f;
            transform.rotation = Quaternion.Euler(0f, 0f, bulletRotation);
        }
        public override void GameUpdate() => _lifeTimeTimer.UpdateTime(Time.deltaTime);
        public void Attack<T>() where T : Entity => _typeOfEntityToAttack = typeof(T);
        protected virtual void OnHitDamageable(IDamageable damageable)
        {
            HitDamageable?.Invoke(damageable);
        }
    }
}