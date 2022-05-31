using UnityEngine;
using System;

namespace Asteroids.Movement
{
    public class MovementDirectionProvider : IDirectionProvider
    {
        public Vector3 Provide()
        {
            Vector3 movementDirection = new Vector2();
            movementDirection.x = Convert.ToInt32(Input.GetKey(KeyCode.D)) + (-Convert.ToInt32(Input.GetKey(KeyCode.A)));
            movementDirection.y = Convert.ToInt32(Input.GetKey(KeyCode.W)) + (-Convert.ToInt32(Input.GetKey(KeyCode.S)));
            return movementDirection.normalized;
        }
    }
}