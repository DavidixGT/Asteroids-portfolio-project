using UnityEngine;
using Asteroids.Utilities;
using Asteroids.Weapon;
using Asteroids;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class LaserBullet : Bullet
{
    [SerializeField]
    private float _laserLength;
    [SerializeField, Range(0.6f, 1f)]
    private float _laserWidth;
    private LaserBeamRenderer _laserBeamRenderer;
    private Vector2 _facingDirection;
    public override void Initialize(Vector2 position, Vector2 direction)
    {
        base.Initialize(position, direction);
        _facingDirection = direction;
        _laserBeamRenderer = new LaserBeamRenderer(GetComponent<MeshFilter>());
    }
    public override void GameUpdate()
    {
        base.GameUpdate();
        if (!Physics.Raycast(gameObject.transform.position, _facingDirection, out RaycastHit laserHit, _laserLength))
        {
            RenderLaserBeam(_laserLength);
            return;
        }
        else if (!laserHit.collider.TryGetComponent(out IDamageable damageable))
        {
            float laserLength = Vector2.Distance(gameObject.transform.position, laserHit.point);
            RenderLaserBeam(laserLength);
            return;
        }
        else if (ClassInheritanceChecker.CheckIfClassInheritsAnotherClass(damageable.GetType(), _typeOfEntityToAttack))
        {
            float laserLength = Vector2.Distance(gameObject.transform.position, laserHit.point);
            RenderLaserBeam(laserLength);
            OnHitDamageable(damageable);
        }
    }
    private void RenderLaserBeam(float laserLength) => _laserBeamRenderer.RenderLaserBeam(laserLength, _laserWidth);
    protected override void OnHitDamageable(IDamageable damageable)
    {
        base.OnHitDamageable(damageable);
        damageable.TakeDamage(_damage);
    }
}
