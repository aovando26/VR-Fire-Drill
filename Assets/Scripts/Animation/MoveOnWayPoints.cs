using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MoveOnWayPoints : MonoBehaviour
{
    public List<GameObject> waypoints;
    public float speed = 2f;
    int index = 0;

    private void Update()
    {
        Vector3 destination = waypoints[index].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPos;

        float distance = Vector3.Distance(transform.position, destination);

        if (distance <= 0.5f)
        {
            index++;
            return;
        }
    }
}
