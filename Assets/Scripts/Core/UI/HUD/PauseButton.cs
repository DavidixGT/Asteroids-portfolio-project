using System;

namespace Asteroids.UI.HUD
{
    public class PauseButton : UIButton
    {
        private bool _isPaused = false;

        public event Action<bool> Paused;
        protected override void Interact()
        {
            if (_isPaused)
                _isPaused = false;
            else
                _isPaused = true;
            Paused?.Invoke(_isPaused);
        }
        public void Register(Action<bool> pauseCallbackListener)
        {
            Paused += pauseCallbackListener;
        }
        public void UnRigester(Action<bool> pauseCallbackListener)
        {
            Paused -= pauseCallbackListener;
        }
    }
}