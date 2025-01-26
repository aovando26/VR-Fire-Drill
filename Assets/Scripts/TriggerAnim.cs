using UnityEngine;

public class TriggerAnim : MonoBehaviour
{
    // Reference to the Animator component
    public Animator animator;
    public bool rollingnWheelchair = false; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Backpack") && !rollingnWheelchair)
        {
            Debug.Log("Player has backpack");

            // Trigger the sitting_rubbing animation
            animator.SetTrigger("still_wheelchair");
            rollingnWheelchair = true; 
        }
    }
}
