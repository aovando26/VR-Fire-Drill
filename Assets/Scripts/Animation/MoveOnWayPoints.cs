using UnityEngine;
using System.Collections.Generic;

public class MoveOnWayPoints : MonoBehaviour
{
    public List<GameObject> waypoints;
    public float speed = 2f;
    private int index = 0;
    public TriggerAnim triggerAnim;

    private void Update()
    {
        if (triggerAnim.rollingWheelchair)
        {
            MoveToNextWaypoint();
        }
    }

    private void MoveToNextWaypoint()
    {
        if (index >= waypoints.Count) return; // Prevent out-of-bounds errors

        Vector3 destination = waypoints[index].transform.position;

        // Move towards the waypoint
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        // Rotate smoothly towards the waypoint direction
        Vector3 direction = (destination - transform.position).normalized;
        if (direction.magnitude > 0.1f) // Prevent unnecessary rotations when very close
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }

        // Check if the object has reached the waypoint
        if (Vector3.Distance(transform.position, destination) <= 0.5f)
        {
            index++;
        }
    }
}
