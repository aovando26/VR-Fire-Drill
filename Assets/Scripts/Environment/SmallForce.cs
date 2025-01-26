using UnityEngine;

public class SmallForce : MonoBehaviour
{
    private Rigidbody rb;
    public float forceMagnitude = 1.0f;
    public Vector3 forceDirection = Vector3.forward;
    public void ObjectFall()
    {
        //AudioSource audioSource = GetComponent<AudioSource>();

        //audioSource.Play();

        rb = GetComponent<Rigidbody>();
        rb.AddForce(forceDirection.normalized * -forceMagnitude, ForceMode.Impulse);
    }
}
