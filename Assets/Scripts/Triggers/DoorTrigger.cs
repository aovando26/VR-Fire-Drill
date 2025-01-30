using UnityEngine;

public class DoorTrigger : MonoBehaviour
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

            AudioManager.Instance.PlayLastAudioLines();
        }
    }
}