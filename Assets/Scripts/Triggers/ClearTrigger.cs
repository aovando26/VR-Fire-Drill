using UnityEngine;
using System.Collections.Generic; // Required for using lists

public class ClearTrigger : MonoBehaviour
{
    private AudioSource audioSource;
    private bool activeTrigger;

    [Header("Trigger Settings")]
    // Drag the 4 waypoints you want to deactivate into this list in the Inspector.
    public List<GameObject> waypointsToDeactivate;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        activeTrigger = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // We no longer check for the "Player" tag. Instead, we check if the object
        // that entered has the MoveOnWayPoints script on it.
        if (other.TryGetComponent<MoveOnWayPoints>(out MoveOnWayPoints mover) && !activeTrigger)
        {
            // --- The condition is met ---
            activeTrigger = true;
            if (audioSource != null)
            {
                audioSource.Play();
            }

            // --- 1. Tell the object to stop moving ---
            Debug.Log(other.name + " entered the ClearTrigger. Stopping its movement.");
            mover.StopMovement();

            // --- 2. Deactivate the specified waypoints ---
            Debug.Log("Deactivating final waypoints.");
            foreach (GameObject waypoint in waypointsToDeactivate)
            {
                if (waypoint != null)
                {
                    waypoint.SetActive(false);
                }
            }
        }
    }
}