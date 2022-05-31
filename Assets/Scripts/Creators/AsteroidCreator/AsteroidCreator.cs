using UnityEngine;
using Asteroids;

[CreateAssetMenu(fileName = "Asteroid creator", menuName = "Creators/Asteroid creator", order = 1)]
public class AsteroidCreator : GameBehaviourCreator<Asteroid>, IAsteroidCreator
{
    [SerializeField]
    private AsteroidData _asteroidData;
    public Asteroid CreateAsteroid(Vector2 position)
    {
        InitializeAsteroidData(position);
        Asteroid asteroidInstance = base.CreateInstance();
        asteroidInstance.Initialize(_asteroidData);
        return asteroidInstance;
    }
    private void InitializeAsteroidData(Vector2 position)
    {
        _asteroidData.Position = position;
    }
}