using UnityEngine;

namespace Asteroids.Movement
{
    public class AnimatedRigidBodyMovement : RigidbodyMovement
    {
        private SpeedCurve _speedCurve;
        public AnimatedRigidBodyMovement(Rigidbody rigidbody, SpeedCurve speedCurve) : base(rigidbody, 1f)
        {
            _speedCurve = speedCurve;
        }
        public override void SetMovementDirection(Vector2 direction)
        {
            _direction += direction * Time.fixedDeltaTime / _speedCurve.SpeedCurveMaxTime;
            _direction = Vector2.ClampMagnitude(_direction, 1f);
        }
        protected override Vector2 CalculateDirection() => _speedCurve.GetAcceleration(_direction);
    }
}