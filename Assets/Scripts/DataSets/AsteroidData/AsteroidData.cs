using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AsteroidData
{
    [HideInInspector]
    public Vector2 Position;
    public int AsteroidHealth;
    public float MovemementSpeed;
    public float RotationSpeed;
}