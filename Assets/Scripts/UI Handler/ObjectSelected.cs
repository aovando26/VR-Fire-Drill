using UnityEngine;

public class ObjectSelected : MonoBehaviour
{
    public GameObject protocolCanvas;
    private bool canvasShown = false;

    public void OnBlockPickedUp()
    {
        if (!canvasShown)
        {
            canvasShown = true;
            protocolCanvas.SetActive(true);
            Invoke("HideCanvas", 3.0f);
        }
    }

    // Deactivates the canvas
    private void HideCanvas()
    {
        protocolCanvas.SetActive(false);
    }
}
