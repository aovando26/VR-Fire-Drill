using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]
public class CollectibleItem : MonoBehaviour
{
    private bool _wasPickedUp = false;

    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnPickedUp);
    }

    private void OnPickedUp(SelectEnterEventArgs args)
    {
        // Ensure this logic only runs once.
        if (!_wasPickedUp)
        {
            _wasPickedUp = true;

            // 1. Notify the GameManager that this item has been collected.
            if (GameManager.Instance != null)
            {
                GameManager.Instance.OnItemPickedUp(this.gameObject);
            }

            // 2. Initiate self-destruction with a 0.5-second delay.
            // The object will disappear from the player's hand after this time.
            Destroy(gameObject, 0.5f);
        }
    }
}