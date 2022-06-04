using System;
using UnityEngine;
using Asteroids.Movement;
using Asteroids.Weapon;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody))]
    public class Player : Entity
    {
        private RigidbodyRotator _rigidbodyRotator;
        private Rigidbody _rigidbody;
        private Weapon.Weapon _weapon;
        private IDirectionProvider _movementDirectionProvider;
        private IDirectionProvider _rotationDirectionProvider;
        public void Initialize(PlayerData playerData)
        {
            _rigidbody = GetComponent<Rigidbody>();
            _weapon = playerData.WeaponData.GetWeapon();
            _movement = new AnimatedRigidBodyMovement(_rigidbody, playerData.SpeedCurve);
            _rigidbodyRotator = new RigidbodyRotator(_rigidbody, playerData.RotationSpeed);
            _movementDirectionProvider = new MovementDirectionProvider();
            _rotationDirectionProvider = new RotationDirectionProvider();
        }
        public async override void GameUpdate()
        {
            if (IsPaused) return;
            if (Input.GetKey(KeyCode.Space))
            {
                Vector2 bulletDirection = new Vector2(Mathf.Cos((transform.localRotation.eulerAngles.z + 90f) * (6.28f / 360f)), Mathf.Sin((transform.localRotation.eulerAngles.z + 90f) * (6.28f / 360f)));
                await _weapon.Shoot(transform.position, bulletDirection);
            }
        }
        public override void GameFixedUpdate()
        {
            if (IsPaused) return;
            _rigidbodyRotator.Rotate(_rotationDirectionProvider.Provide());
            _movement.SetMovementDirection(_movementDirectionProvider.Provide());
            _movement.Move();
        }
    }
}