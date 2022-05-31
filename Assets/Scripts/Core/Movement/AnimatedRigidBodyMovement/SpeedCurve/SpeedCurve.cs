using UnityEngine;

namespace Asteroids.Movement
{
    [System.Serializable]
    public class SpeedCurve
    {
        public float MaxSpeed => _speedCurve.Evaluate(SpeedCurveMaxTime);
        public float SpeedCurveMaxTime => _speedCurve.keys[_speedCurve.keys.Length - 1].time;
        [SerializeField]
        private AnimationCurve _speedCurve;
        private bool _initialized => _speedCurve.preWrapMode == WrapMode.PingPong;
        private void Initialize()
        {
            if (_initialized) return;
            _speedCurve.preWrapMode = WrapMode.PingPong;
        }
        public Vector2 GetAcceleration(Vector2 direction)
        {
            Initialize();
            Vector2 acceleration = new Vector2();
            if (IsMovingAlong(direction.x))
                acceleration.x = _speedCurve.Evaluate(direction.x * SpeedCurveMaxTime) * (direction.x / Mathf.Abs(direction.x));
            if (IsMovingAlong(direction.y))
                acceleration.y = _speedCurve.Evaluate(direction.y * SpeedCurveMaxTime) * (direction.y / Mathf.Abs(direction.y));
            return acceleration;
        }
        private bool IsMovingAlong(float axis) => axis != 0;
    }
}