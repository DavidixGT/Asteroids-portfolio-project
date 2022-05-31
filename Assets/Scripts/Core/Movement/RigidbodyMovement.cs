using UnityEngine;

namespace Asteroids.Movement
{
    public class RigidbodyMovement
    {
        private Rigidbody _rigidBody;
        protected Vector2 _direction;
        private float _movementSpeed;
        public RigidbodyMovement(Rigidbody rigidbody, float movementSpeed)
        {
            _rigidBody = rigidbody;
            _movementSpeed = movementSpeed;
        }
        public void ReflectDirection(Vector2 normal) => _direction = Vector2.Reflect(_direction, normal);
        public virtual void SetMovementDirection(Vector2 direction)
        {
            _direction = direction;
        }
        public void Move()
        {
            _rigidBody.MovePosition(_rigidBody.position + _movementSpeed * (Vector3)CalculateDirection() * Time.fixedDeltaTime);
        }
        protected virtual Vector2 CalculateDirection() => _direction;
    }
}
