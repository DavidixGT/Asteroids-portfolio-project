using System;

namespace Asteroids.Score
{
    public class ScoreCounter
    {
        private int _score;
        public int Score => _score;

        public event Action<int> ScoreChanged;
        public void AddPoint()
        {
            _score += 1;
            ScoreChanged?.Invoke(_score);
        }
    }
}
