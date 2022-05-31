using UnityEngine;

namespace Asteroids.Score
{
    public class ScoreSaver
    {
        public int LoadHighestScore() => PlayerPrefs.GetInt("HighestScore", 0);
        public void SaveHighestScore(int score)
        {
            if (score > PlayerPrefs.GetInt("HighestScore", 0))
                PlayerPrefs.SetInt("HighestScore", score);
        }
    }
}