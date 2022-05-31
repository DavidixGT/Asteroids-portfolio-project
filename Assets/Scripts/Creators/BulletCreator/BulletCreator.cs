using System;
using UnityEngine;
using Asteroids.Weapon;

[CreateAssetMenu(fileName = "Bullet creator", menuName = "Creators/Bullet creator", order = 1)]
public class BulletCreator : ScriptableObject, IBulletCreator
{
    public Action<GameBehaviour> GameBehaviourCreated;
    public Bullet CreateBullet(Vector2 position, Vector2 direction, Bullet bullet)
    {
        Bullet bulletInstance = Instantiate(bullet);
        GameBehaviourCreated?.Invoke(bulletInstance);
        bulletInstance.Initialize(position, direction);
        return bulletInstance;
    }
}