using UnityEngine;

public class SelfDestroy : MonoBehaviour
{

    public bool objectDestroyed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnDestroy()
    {
        Destroy(gameObject, .5f);
        objectDestroyed = true;
    }
}
