using UnityEngine;

[System.Serializable]
public class BulletData
{
    [HideInInspector]
    public Vector2 Position;
    [HideInInspector]
    public float Rotation;
    public float LifeTime = 3f;
    public float MovementSpeed = 3f;
}
