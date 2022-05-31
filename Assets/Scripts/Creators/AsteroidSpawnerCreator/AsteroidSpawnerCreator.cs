using UnityEngine;
using Asteroids;

[CreateAssetMenu(fileName = "AsteroidSpawner creator", menuName = "Creators/AsteroidSpawner creator", order = 1)]
public class AsteroidSpawnerCreator : GameBehaviourCreator<AsteroidSpawner>
{
    [SerializeField]
    private AsteroidSpawnerData _asteroidSpawnerData;
    public AsteroidSpawner CreateAsteroidSpawner(IAsteroidCreator asteroidCreator)
    {
        Initialize(asteroidCreator);
        AsteroidSpawner asteroidSpawnerInstance = CreateInstance();
        asteroidSpawnerInstance.Initialize(_asteroidSpawnerData);
        return asteroidSpawnerInstance;
    }
    public void Initialize(IAsteroidCreator asteroidCreator)
    {
        _asteroidSpawnerData.AsteroidCreator = asteroidCreator;
    }
}
