using UnityEngine;
using Asteroids.Movement;

namespace Asteroids
{
    public class Collideable : GameBehaviour
    {
        protected RigidbodyMovement _movement;
        protected void OnCollisionEnter(Collision collision)
        {
            _movement.ReflectDirection(collision.contacts[0].normal);
        }
    }
}
