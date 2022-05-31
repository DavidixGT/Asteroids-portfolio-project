using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
    public abstract class Enemy : Entity
    {
        private new void OnCollisionEnter(Collision collision)
        {
            base.OnCollisionEnter(collision);
            if (collision.collider.TryGetComponent(out Player damageable))
                OnHitPlayer(damageable);
        }
        protected abstract void OnHitPlayer(Player player);
    }
}