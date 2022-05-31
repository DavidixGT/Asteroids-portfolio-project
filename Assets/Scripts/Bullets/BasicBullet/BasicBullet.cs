using UnityEngine;
using Asteroids;
using Asteroids.Weapon;
using Asteroids.Movement;
using Asteroids.Utilities;

[RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
public class BasicBullet : Bullet
{
    [SerializeField]
    private float _movementSpeed;
    private RigidbodyMovement _rigidbodyMovement;
    private Vector3 _movementDirection;
    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.TryGetComponent(out IDamageable damageable))
            return;
        else if (ClassInheritanceChecker.CheckIfClassInheritsAnotherClass(damageable.GetType(), _typeOfEntityToAttack))
            OnHitDamageable(damageable);
    }
    public override void Initialize(Vector2 position, Vector2 direction)
    {
        base.Initialize(position, direction);
        _rigidbodyMovement = new RigidbodyMovement(GetComponent<Rigidbody>(), _movementSpeed);
        _movementDirection = direction;
    }
    public override void GameUpdate()
    {
        base.GameUpdate();
        _rigidbodyMovement.SetMovementDirection(_movementDirection);
        _rigidbodyMovement.Move();
    }
    protected override void OnHitDamageable(IDamageable damageable)
    {
        base.OnHitDamageable(damageable);
        damageable.TakeDamage(_damage);
        Destroy(gameObject);
    }
}