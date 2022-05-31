using UnityEngine;
using System;

namespace Asteroids.Movement
{
    public class RotationDirectionProvider : IDirectionProvider
    {
        public Vector3 Provide()
        {
            return new Vector3(0, 0, Convert.ToInt32(Input.GetKey(KeyCode.LeftArrow))
                                 + (-Convert.ToInt32(Input.GetKey(KeyCode.RightArrow)))).normalized;
        }
    }
}