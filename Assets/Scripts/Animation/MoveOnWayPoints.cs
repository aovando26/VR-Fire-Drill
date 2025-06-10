using UnityEngine;
using System.Collections.Generic;

public class MoveOnWayPoints : MonoBehaviour
{
    [Header("Path Setup")]
    // Drag ALL 9 waypoints here in the correct order.
    // The first 5 should be active in the scene, the last 4 should be deactivated.
    public List<GameObject> allWaypoints;

    [Header("Activation Logic")]
    // The list of currently deactivated waypoints you want to turn on.
    public List<GameObject> waypointsToActivate;
    // Activate the new waypoints after completing the waypoint at this index.
    // Since you have 5 active waypoints (indices 0, 1, 2, 3, 4), you'd set this to 4.
    public int activationWaypointIndex = 4;

    [Header("Movement Settings")]
    public float speed = 2f;
    public float rotationSpeed = 5f;

    private int _currentIndex = 0;
    private bool _hasMovementStarted = false;
    private bool _newWaypointsHaveBeenActivated = false;

    private void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.onAllItemsCollected.AddListener(StartMoving);
        }
    }

    private void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.onAllItemsCollected.RemoveListener(StartMoving);
        }
    }

    private void StartMoving()
    {
        Debug.Log("Event received by MoveOnWayPoints! Starting movement.");
        _hasMovementStarted = true;
    }

    private void Update()
    {
        if (_hasMovementStarted)
        {
            MoveToNextWaypoint();
        }
    }

    private void MoveToNextWaypoint()
    {
        if (_currentIndex >= allWaypoints.Count) return;

        Vector3 destination = allWaypoints[_currentIndex].transform.position;
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        Vector3 direction = (destination - transform.position).normalized;
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Check if we have arrived at the destination waypoint.
        if (Vector3.Distance(transform.position, destination) <= 0.5f)
        {
            // --- NEW LOGIC IS HERE ---
            // Check if we have just arrived at the trigger waypoint AND we haven't activated the new ones yet.
            if (!_newWaypointsHaveBeenActivated && _currentIndex == activationWaypointIndex)
            {
                ActivateNextWaypoints();
            }
            // --- END OF NEW LOGIC ---

            _currentIndex++;
        }
    }

    /// <summary>
    /// Activates the next set of waypoints.
    /// </summary>
    public void ActivateNextWaypoints()
    {
        Debug.Log("Activating the next set of waypoints.");
        foreach (GameObject waypoint in waypointsToActivate)
        {
            if (waypoint != null)
            {
                waypoint.SetActive(true);
            }
        }
        // Set the flag to true so we don't run this logic more than once.
        _newWaypointsHaveBeenActivated = true;
    }
    // Add this entire method to your MoveOnWayPoints.cs script

    /// <summary>
    /// Public method that can be called from other scripts to stop the movement.
    /// </summary>
    public void StopMovement()
    {
        Debug.Log("StopMovement() called. Halting waypoint movement.");
        _hasMovementStarted = false;
    }
}