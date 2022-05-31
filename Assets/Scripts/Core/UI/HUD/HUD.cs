using System;
using UnityEngine;
using Asteroids.UI.HUD.Score;

namespace Asteroids.UI.HUD
{
    public class HUD : GameBehaviour
    {
        [SerializeField]
        private PauseButton _pauseButton;
        [SerializeField]
        private ScoreView _scoreView;
        public ScoreView ScoreView => _scoreView;
        public void RigisterToPauseEvent(Action<bool> pauseCallbackListener)
        {
            _pauseButton.Register(pauseCallbackListener);
        }
        public void UnrigisterToPauseEvent(Action<bool> pauseCallbackListener)
        {
            _pauseButton.UnRigester(pauseCallbackListener);
        }
    }
}