using UnityEngine;
using UnityEngine.UIElements;

public class FollowWheelchair : MonoBehaviour
{

    public Transform teen;
    public Transform wheelChair;
    //public Vector3 offset;
    private bool isSet = false;
    //[SerializeField]
    //private Vector3 offset = new Vector3(0, -1.0f, -1.0f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void TeenSitsOnWheelChair()
    {
        if (!isSet)
        {
            teen.transform.position = transform.position;
            isSet = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isSet)
        {
            // Synchronize position and rotation
            wheelChair.transform.position = teen.transform.position;
            wheelChair.transform.rotation = teen.transform.rotation;
        }
    }
}
