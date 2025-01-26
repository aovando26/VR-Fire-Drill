using UnityEngine;

public class SmallForce : MonoBehaviour
{
    private Rigidbody rb;

    public void ObjectFall()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward * -1.0f, ForceMode.Impulse);
    }
}
