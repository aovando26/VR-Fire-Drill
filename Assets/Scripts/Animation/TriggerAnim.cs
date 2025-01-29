using UnityEngine;

public class TriggerAnim : MonoBehaviour
{
    // Reference to the Animator component
    public Animator animator;
    public bool rollingWheelchair;

    private void Start()
    {
        rollingWheelchair = false;
    }
    private string animClip = "still_wheelchair";
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Backpack") && !rollingWheelchair)
        {
            Debug.Log("Player has backpack");
            Debug.Log("Trigger activated: Switching to running animation");
            // Trigger the sitting_rubbing animation
            animator.Play(animClip);
            rollingWheelchair = true;
        }
    }
}
