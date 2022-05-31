using UnityEngine;

namespace Asteroids.Movement
{
    public class AsteroidMovement : RigidbodyMovement
    {
        private Transform _asteroidTransform;
        private Collider _asteroidCollider;
        public AsteroidMovement(Rigidbody rigidbody, float movementSpeed) : base(rigidbody, movementSpeed)
        {
            _asteroidTransform = rigidbody.transform;
            _asteroidCollider = rigidbody.GetComponent<Collider>();
            float x = _asteroidTransform.position.x;
            float y = _asteroidTransform.position.y;
            float rotationTowardsZero = Mathf.Acos(((x * 1f) + (y * 0)) / Mathf.Sqrt(x * x + y * y)) / (6.28f / 360);
            _direction = new Vector2(-Mathf.Cos(rotationTowardsZero * (6.28f / 360)), -(1f / y * Mathf.Abs(y)) * Mathf.Sin(rotationTowardsZero * (6.28f / 360)));
        }
        private bool HitOtherCollider(out Transform colliderTransform)
        {
            colliderTransform = null;
            Collider[] collisionColliders = Physics.OverlapSphere(_asteroidTransform.position, 0.5f);
            if (collisionColliders.Length == 0) return false;
            colliderTransform = collisionColliders[0].transform;
            if (colliderTransform == _asteroidTransform) return false;
            return true;
        }
    }
}
