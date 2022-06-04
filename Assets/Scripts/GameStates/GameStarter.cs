using UnityEngine;
using Asteroids.UI.HUD;
using Asteroids.Score;

namespace Asteroids
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField]
        private CreatorManager _creatorManager;
        [SerializeField]
        private GameBehaviourUpdater _gameBehaviourUpdaterPrefab;
        [SerializeField]
        private HUD _playerHUDPrefab;
        [SerializeField]
        private GameOverPanel _gameOverPanelPrefab;
        private GameBehaviourUpdater _gameBehaviourUpdater;
        private ScoreControler _scoreControler;
        private void Awake()
        {
            GameBehaviourUpdater gameBehaviourUpdaterInstance = CreateGameBehaviourUpdater();
            GameOverPanel gameOverPanelInstance = Instantiate(_gameOverPanelPrefab);
            gameOverPanelInstance.Hide();
            HUD hUDInstance = Instantiate(_playerHUDPrefab);
            hUDInstance.RigisterToPauseEvent(_gameBehaviourUpdater.PauseGameBehaviours);
            _scoreControler = new ScoreControler(hUDInstance.ScoreView);
            _creatorManager.CreateAsteroidSpawner().AsteroidDied += _scoreControler.AddPoint;
            Player playerInstance = _creatorManager.CreatePlayer();
            playerInstance.Dead += (Entity entity) => 
            {
                gameOverPanelInstance.Initialize(_scoreControler.GetCurrentSessionScore(), _scoreControler.GetHighestScore());
                gameOverPanelInstance.Show(); 
            };
            playerInstance.Dead += (Entity entity) => { gameBehaviourUpdaterInstance.PauseGameBehaviours(true); };
        }
        private void OnDisable() => _creatorManager.UnsubscribeToGameBehaviourCreation(_gameBehaviourUpdater.TryToAddGameBehaviour);
        private GameBehaviourUpdater CreateGameBehaviourUpdater()
        {
            GameBehaviourUpdater gameBehaviourUpdaterInstance = _gameBehaviourUpdater = Instantiate(_gameBehaviourUpdaterPrefab);
            _creatorManager.SubscribeToGameBehaviourCreation(_gameBehaviourUpdater.TryToAddGameBehaviour);
            return gameBehaviourUpdaterInstance;
        }
    }
}