using UnityEngine;

namespace Asteroids.Utilities
{
    public class LifeTimeTimer
    {
        private GameBehaviour _gameBehaviour;
        private float _lifeTime;
        private bool _isLifeTimeIsOver => _lifeTime <= 0;
        public LifeTimeTimer(GameBehaviour gameBehaviourTodestroy, float lifeTime)
        {
            _gameBehaviour = gameBehaviourTodestroy;
            _lifeTime = lifeTime;
        }
        public void UpdateTime(float deltaTime)
        {
            if (_isLifeTimeIsOver)
                Object.Destroy(_gameBehaviour.gameObject);
            else
                _lifeTime -= deltaTime;
        }
    }
}