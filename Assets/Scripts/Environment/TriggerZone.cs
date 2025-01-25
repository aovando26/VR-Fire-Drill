using UnityEngine;

public class TriggerZone : MonoBehaviour
{

    public SmallForce smallForce;

    private void OnTriggerEnter(Collider other)
    {
        smallForce.ObjectFall();
    }
}
