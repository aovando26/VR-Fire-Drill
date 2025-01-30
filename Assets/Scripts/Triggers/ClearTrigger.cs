using UnityEngine;

public class ClearTrigger : MonoBehaviour
{
    public AudioSource audioSource;
    private bool activeTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!activeTrigger)
        {
            audioSource.Play();
        }
    }
}