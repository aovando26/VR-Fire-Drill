using UnityEngine;

public class SmallForce : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void ObjectFall()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right * 1.5f, ForceMode.Impulse);
    }
}
