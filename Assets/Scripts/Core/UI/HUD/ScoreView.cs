using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Asteroids.UI.HUD.Score
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ScoreView : MonoBehaviour
    {
        private TextMeshProUGUI _score;
        public void Awake()
        {
            _score = GetComponent<TextMeshProUGUI>();
        }
        public void UpdateScore(int score)
        {
            _score.text = score.ToString();
        }
    }
}