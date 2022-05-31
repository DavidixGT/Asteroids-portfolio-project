using UnityEngine;

public class RigidbodyRotator
{
    private Rigidbody _rigidBody;
    private float _rotationSpeed;
    public RigidbodyRotator(Rigidbody rigidBody, float rotationSpeed)
    {
        _rotationSpeed = rotationSpeed;
        _rigidBody = rigidBody;
    }
    public void Rotate(Vector3 direction)
    {
        Quaternion rotationVelocity = Quaternion.Euler(direction * _rotationSpeed * Time.fixedDeltaTime);
        _rigidBody.MoveRotation(_rigidBody.rotation * rotationVelocity);
    }
}