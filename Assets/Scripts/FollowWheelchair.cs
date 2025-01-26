using UnityEngine;

public class FollowWheelchair : MonoBehaviour
{

    public Transform wheelChair;
    public Vector3 offset;
    private bool isSet = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void TeenSitsOnWheelChair()
    {
        if (!isSet)
        {
            wheelChair.transform.position = transform.position + offset;
            isSet = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
