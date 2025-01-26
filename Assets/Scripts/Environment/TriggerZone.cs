using UnityEngine;

public class TriggerZone : MonoBehaviour
{

    public SmallForce smallForce;
    public AudioSource audioSource;
    private bool activeTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!activeTrigger)
        {
            if (audioSource != null)
            {
                audioSource.Play();
            }
            smallForce.ObjectFall();
            activeTrigger = true;
        }
    }
}
