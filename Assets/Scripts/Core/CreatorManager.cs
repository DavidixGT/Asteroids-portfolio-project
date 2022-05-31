using System;
using System.Collections.Generic;
using UnityEngine;
using Asteroids;

[CreateAssetMenu(fileName = "CreatorManager", menuName = "Creators/CreatorManager", order = 1)]
public class CreatorManager : ScriptableObject, IPlayerCreator, IAsteroidCreator
{
    [SerializeField]
    private BulletCreator _bulletCreator;
    [SerializeField]
    private PlayerCreator _playerCreator;
    [SerializeField]
    private AsteroidCreator _asteroidCreator;
    [SerializeField]
    private AsteroidSpawnerCreator _asteroidSpawnerCreator;
    private List<Action<GameBehaviour>> _gameBehaviourCreationSubscribers = new List<Action<GameBehaviour>>();
    public void SubscribeToGameBehaviourCreation(Action<GameBehaviour> action)
    {
        _bulletCreator.GameBehaviourCreated += action;
        _playerCreator.GameBehaviourCreated += action;
        _asteroidCreator.GameBehaviourCreated += action;
        _asteroidSpawnerCreator.GameBehaviourCreated += action;
        _gameBehaviourCreationSubscribers.Add(action);
    }
    public void UnsubscribeToGameBehaviourCreation(Action<GameBehaviour> action)
    {
        Action<GameBehaviour> gameBehaviourCreationSubscriber = _gameBehaviourCreationSubscribers.Find(x => x == action);
        _bulletCreator.GameBehaviourCreated -= gameBehaviourCreationSubscriber;
        _playerCreator.GameBehaviourCreated -= gameBehaviourCreationSubscriber;
        _asteroidCreator.GameBehaviourCreated -= gameBehaviourCreationSubscriber;
        _asteroidSpawnerCreator.GameBehaviourCreated -= gameBehaviourCreationSubscriber;
    }
    public AsteroidSpawner CreateAsteroidSpawner() => _asteroidSpawnerCreator.CreateAsteroidSpawner(this);
    public Player CreatePlayer() => _playerCreator.CreatePlayer();
    public Asteroid CreateAsteroid(Vector2 position) => _asteroidCreator.CreateAsteroid(position);
}