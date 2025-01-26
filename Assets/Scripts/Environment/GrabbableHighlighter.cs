using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabbableHighlighter : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Renderer objectRenderer;
    private Material originalMaterial;

    [Header("Highlight Settings")]
    public Material highlightMaterial;

    private void Awake()
    {
        // Get required components
        grabInteractable = GetComponent<XRGrabInteractable>();
        objectRenderer = GetComponent<Renderer>();

        // Store the original material
        if (objectRenderer != null)
        {
            originalMaterial = objectRenderer.material;
        }

        // Subscribe to hover events
        grabInteractable.hoverEntered.AddListener(OnHoverEnter);
        grabInteractable.hoverExited.AddListener(OnHoverExit);
    }

    private void OnDestroy()
    {
        // Unsubscribe from hover events
        grabInteractable.hoverEntered.RemoveListener(OnHoverEnter);
        grabInteractable.hoverExited.RemoveListener(OnHoverExit);
    }

    private void OnHoverEnter(HoverEnterEventArgs args)
    {
        if (objectRenderer != null && highlightMaterial != null)
        {
            objectRenderer.material = highlightMaterial;
        }
    }

    private void OnHoverExit(HoverExitEventArgs args)
    {
        if (objectRenderer != null && originalMaterial != null)
        {
            objectRenderer.material = originalMaterial;
        }
    }
}
