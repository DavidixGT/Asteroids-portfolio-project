using UnityEngine;
using Asteroids.Movement;

namespace Asteroids
{
    public class Asteroid : Enemy
    {
        private RigidbodyRotator _asteroidRotator;
        public void Initialize(AsteroidData asteroidData)
        {
            _health = asteroidData.AsteroidHealth;
            gameObject.transform.position = asteroidData.Position;
            _movement = new AsteroidMovement(GetComponent<Rigidbody>(), asteroidData.MovemementSpeed);
            _asteroidRotator = new RigidbodyRotator(GetComponent<Rigidbody>(), asteroidData.RotationSpeed);
        }
        public override void GameUpdate()
        {
            if (IsPaused) return;
            _movement.Move();
            _asteroidRotator.Rotate(transform.forward);
        }
        protected override void OnHitPlayer(Player player)
        {
            player.TakeDamage(player.Health);
        }
    }
}