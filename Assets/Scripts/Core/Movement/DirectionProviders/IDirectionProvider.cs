using UnityEngine;

namespace Asteroids.Movement
{
    public interface IDirectionProvider
    {
        public Vector3 Provide();
    }
}