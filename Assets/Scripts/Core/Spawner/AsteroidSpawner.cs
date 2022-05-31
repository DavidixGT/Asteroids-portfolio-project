using System;
using UnityEngine;
using Asteroids.Utilities;

namespace Asteroids
{
    public class AsteroidSpawner : GameBehaviour
    {
        private IAsteroidCreator _asteroidCreator;
        private CoolDown _coolDown;
        private float _asteroidSpawnRadius;
        private EntityLimitChecker _asteroidsLimitChecker;
        private bool _canProduceAsteroid => _coolDown.IsCompleted && !IsPaused && !_asteroidsLimitChecker.IsEntityLimitReached();

        public event Action AsteroidDied;
        public void Initialize(AsteroidSpawnerData asteroidSpawnerData)
        {
            _asteroidCreator = asteroidSpawnerData.AsteroidCreator;
            _coolDown = new CoolDown(asteroidSpawnerData.CoolDownTime);
            _asteroidSpawnRadius = asteroidSpawnerData.AsteroidSpawnRadius;
            _asteroidsLimitChecker = new EntityLimitChecker(asteroidSpawnerData.AsteroidsCountLimit);
        }
        public override void GameUpdate()
        {
            Spawn();
        }
        public async void Spawn()
        {
            if (_canProduceAsteroid)
            {
                Asteroid asteroid = _asteroidCreator.CreateAsteroid(GetRandomPositionInsideTheCircle());
                _asteroidsLimitChecker.AddEntity(asteroid);
                asteroid.Dead += (Entity entity) => { AsteroidDied?.Invoke(); };
                await _coolDown.StartCoolDown();
            }
        }
        private Vector2 GetRandomPositionInsideTheCircle()
        {
            Vector2 spawnPosition = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f));
            float angle = Mathf.Asin(spawnPosition.x) / (6.28f / 360f);
            Vector2 spawnPositionInsideOfCircle = new Vector2(Mathf.Sin(angle * (6.28f / 360f)), Mathf.Cos(angle * (6.28f / 360f)) * (1f / spawnPosition.y * Mathf.Abs(spawnPosition.y)));
            return spawnPositionInsideOfCircle * _asteroidSpawnRadius;
        }
    }
}