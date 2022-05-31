using Asteroids;

[System.Serializable]
public class AsteroidSpawnerData
{
    public IAsteroidCreator AsteroidCreator;
    public int CoolDownTime;
    public float AsteroidSpawnRadius;
    public int AsteroidsCountLimit;
}