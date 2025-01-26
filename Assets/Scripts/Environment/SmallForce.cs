using UnityEngine;

public class SmallForce : MonoBehaviour
{
    private Rigidbody rb;
    public float forceMagnitude = 1.0f;
    public Vector3 forceDirection = Vector3.forward;
    public void ObjectFall()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(forceDirection.normalized * -forceMagnitude, ForceMode.Impulse);
    }
}
