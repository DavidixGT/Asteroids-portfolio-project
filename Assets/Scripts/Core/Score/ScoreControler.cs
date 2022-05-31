using Asteroids.UI.HUD.Score;

namespace Asteroids.Score
{
    public class ScoreControler
    {
        private ScoreView _scoreView;
        private ScoreSaver _scoreSaver;
        private ScoreCounter _scoreCounter;
        public ScoreControler(ScoreView scoreView)
        {
            _scoreView = scoreView;
            _scoreSaver = new ScoreSaver();
            _scoreCounter = new ScoreCounter();
            _scoreCounter.ScoreChanged += _scoreSaver.SaveHighestScore;
            _scoreCounter.ScoreChanged += _scoreView.UpdateScore;
        }
        public void AddPoint()
        {
            _scoreCounter.AddPoint();
        }
        public int GetCurrentSessionScore() => _scoreCounter.Score;
        public int GetHighestScore() => _scoreSaver.LoadHighestScore();
        ~ScoreControler()
        {
            _scoreCounter.ScoreChanged -= _scoreSaver.SaveHighestScore;
            _scoreCounter.ScoreChanged -= _scoreView.UpdateScore;
        }
    }
}