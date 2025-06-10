using UnityEngine;

public class ClearTrigger : MonoBehaviour
{
    private AudioSource audioSource;
    private bool activeTrigger;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        activeTrigger = false;
        //if (audioSource == null)
        //{
        //    Debug.LogError("No AudioSource found on " + gameObject.name);
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && audioSource != null && !activeTrigger)
        {
            audioSource.Play();
            activeTrigger = true;
        }
    }
}