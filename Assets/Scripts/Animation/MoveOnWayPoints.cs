using UnityEngine;
using System.Collections.Generic;

public class MoveOnWayPoints : MonoBehaviour
{
    [Header("Path Setup")]
    // Drag ALL 9 waypoints here in the correct order.
    // The first 5 should be active in the scene, the last 4 should be deactivated.
    public List<GameObject> allWaypoints;


    [Header("Movement Settings")]
    public float speed = 2f;
    public float rotationSpeed = 5f;

    private int _currentIndex = 0;
    private bool _hasMovementStarted = false;

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

        if (Vector3.Distance(transform.position, destination) <= 0.5f)
        {
            _currentIndex++;
        }
    }
    /// <summary>
    /// Public method that can be called from other scripts to stop the movement.
    /// </summary>
    public void StopMovement()
    {
        Debug.Log("StopMovement() called. Halting waypoint movement.");
        _hasMovementStarted = false;
    }
}