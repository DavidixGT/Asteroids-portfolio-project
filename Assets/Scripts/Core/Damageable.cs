using System;
using UnityEngine;

namespace Asteroids
{
    public interface IDamageable
    {
        public event Action<Entity> Dead;
        public void TakeDamage(float damage);
    }
}