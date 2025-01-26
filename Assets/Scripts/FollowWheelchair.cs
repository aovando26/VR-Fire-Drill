using UnityEngine;

public class FollowWheelchair : MonoBehaviour
{

    public Transform wheelChair;
    public Vector3 offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void TeenSitsOnWheelChair()
    {
        wheelChair.transform.position = transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
