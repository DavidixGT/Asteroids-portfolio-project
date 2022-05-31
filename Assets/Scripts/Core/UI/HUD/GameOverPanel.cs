using UnityEngine;
using Asteroids.UI.HUD.Score;

namespace Asteroids.UI.HUD
{
    public class GameOverPanel : UIPanel
    {
        [SerializeField]
        private ScoreView _sessionScore;
        [SerializeField]
        private ScoreView _highestScore;
        public void Initialize(int sessionScore, int highestScore)
        {
            _sessionScore.UpdateScore(sessionScore);
            _highestScore.UpdateScore(highestScore);
        }
    }
}