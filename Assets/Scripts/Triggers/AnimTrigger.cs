using UnityEngine;
using UnityEngine.Audio;

public class AnimTrigger : MonoBehaviour
{
    private AudioSource audioSource;
    // Reference to the Animator component
    public Animator animator;
    public bool rollingWheelchair;
    public SelfDestroy selfDestroy;

    private void Start()
    {
        rollingWheelchair = false;
        audioSource = GetComponent<AudioSource>();
    }
    private string animClip = "still_wheelchair";
    private void OnTriggerStay(Collider other)
    {
        if (selfDestroy.objectDestroyed && !rollingWheelchair && other.gameObject.CompareTag("Player")) 
        {
            Debug.Log("Player has backpack");
            Debug.Log("Trigger activated: Switching to running animation");
            // Trigger the sitting_rubbing animation
            animator.Play(animClip);
            rollingWheelchair = true;
            audioSource.Play();
        }
    }
}
