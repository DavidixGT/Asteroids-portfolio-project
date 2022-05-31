using UnityEngine;

namespace Asteroids
{
    public interface IAsteroidCreator
    {
        public Asteroid CreateAsteroid(Vector2 position);
    }
}