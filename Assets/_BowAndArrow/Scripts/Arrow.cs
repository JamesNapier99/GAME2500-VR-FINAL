using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float Speed = 2000.0f;
    public Transform Tip = null;

    private Rigidbody RigidBody = null;
    private bool IsStopped = true;
    private Vector3 LastPosition = Vector3.zero;

    private void Awake()
    {
        RigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (IsStopped)
            return;

        // Rotate
        RigidBody.MoveRotation(Quaternion.LookRotation(RigidBody.velocity, transform.up));
        // Collision
        if (Physics.Linecast(LastPosition, Tip.position))
            Stop();

        // Store Position
        LastPosition = Tip.position;
    }

    private void Stop()
    {
        IsStopped = true;

        RigidBody.isKinematic = true;
        RigidBody.useGravity = false;
    }

    public void Fire(float pullValue)
    {
        IsStopped = false;
        transform.parent = null;

        RigidBody.isKinematic = false;
        RigidBody.useGravity = true;
        RigidBody.AddForce(transform.forward * (pullValue * Speed));

        Destroy(gameObject, 5.0f); // Automatic scene management for removing the arrow
    }
}
