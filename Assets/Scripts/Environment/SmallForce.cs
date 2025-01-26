using UnityEngine;

public class SmallForce : MonoBehaviour
{
    private Rigidbody rb;

    public void ObjectFall()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right * 1.5f, ForceMode.Impulse);
    }
}
