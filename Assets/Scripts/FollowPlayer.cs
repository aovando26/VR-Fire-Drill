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
            // Smoothly move towards the followPlayer's position
            transform.position = Vector3.MoveTowards(
                transform.position,
                followPlayer.position,
                speed * Time.deltaTime
            );
        }
    }
}
