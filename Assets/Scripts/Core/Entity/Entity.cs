using System;

namespace Asteroids
{
    public class Entity : Collideable, IDamageable
    {
        protected float _health;
        public float Health => _health;
        private bool _isDead => _health <= 0;

        public event Action<Entity> Dead;
        public void TakeDamage(float damage)
        {
            if (damage < 0 || IsPaused) return;
            _health -= damage;
            if (_isDead)
                Die();
        }
        private void Die()
        {
            Dead?.Invoke(this);
            Destroy(gameObject);
        }
    }

}