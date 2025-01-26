using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform followPlayer; // The object to follow
    public TriggerAnim triggerAnim; // Reference to the TriggerAnim script
    public float speed = 5.0f;

    void Start()
    {
        if (triggerAnim == null)
        {
            Debug.LogError("TriggerAnim reference not assigned!");
        }
    }

    void Update()
    {
        // Only follow the player if rollingnWheelchair is true
        if (triggerAnim != null && triggerAnim.rollingnWheelchair)
        {
            // Decrease the y position by 1
            Vector3 targetPosition = followPlayer.position;
            targetPosition.y -= 1; // Decrease y by 1

            // Smoothly move towards the new target position
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPosition,
                speed * Time.deltaTime
            );
        }
    }
}
