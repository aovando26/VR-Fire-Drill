using UnityEngine;

public class PathTrigger : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Debris 1")
        {
            GameManager.Instance.CheckDebris();
        }
        else if (other.name == "Debris 2")
        {
            GameManager.Instance.CheckDebris();
        }
    }
}
