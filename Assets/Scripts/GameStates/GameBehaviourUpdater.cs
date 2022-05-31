using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class GameBehaviourUpdater : MonoBehaviour
    {
        [SerializeField]
        private List<GameBehaviour> _gameBehaviours = new List<GameBehaviour>();
        private void Update()
        {
            for (int i = 0; i < _gameBehaviours.Count; i++)
            {
                if (_gameBehaviours[i])
                    _gameBehaviours[i].GameUpdate();
                else
                    _gameBehaviours.Remove(_gameBehaviours[i]);
            }
        }
        private void FixedUpdate()
        {
            for (int i = 0; i < _gameBehaviours.Count; i++)
            {
                if (_gameBehaviours[i])
                    _gameBehaviours[i].GameFixedUpdate();
                else
                    _gameBehaviours.Remove(_gameBehaviours[i]);
            }
        }
        public void TryToAddGameBehaviour(GameBehaviour gameBehaviour)
        {
            if (gameBehaviour != null)
                _gameBehaviours.Add(gameBehaviour);
        }
        public void RemoveGameBehaviour(GameBehaviour gameBehaviour)
        {
            _gameBehaviours.Remove(gameBehaviour);
        }
        public void PauseGameBehaviours(bool pause)
        {
            foreach (GameBehaviour gameBehaviour in _gameBehaviours)
                gameBehaviour.SetPause(pause);
        }
    }
}