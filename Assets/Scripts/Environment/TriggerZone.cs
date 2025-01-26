using UnityEngine;

public class TriggerZone : MonoBehaviour
{

    public SmallForce smallForce;
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
        smallForce.ObjectFall();
    }
}
