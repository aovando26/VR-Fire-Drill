using UnityEngine;

public class TriggerZone : MonoBehaviour
{

    public SmallForce smallForce;
    public AudioSource audioSource;
    private bool activeTrigger = false;
    public AudioClip doorClip;
    public AudioClip exitClip;

    private void OnTriggerEnter(Collider other)
    {
        if (!activeTrigger)
        {
            if (audioSource != null)
            {
                audioSource.PlayOneShot(doorClip, 1.0f);
            }
            smallForce.ObjectFall();
            activeTrigger = true;

            audioSource.PlayOneShot(exitClip, 1.0f);
        }
    }
}