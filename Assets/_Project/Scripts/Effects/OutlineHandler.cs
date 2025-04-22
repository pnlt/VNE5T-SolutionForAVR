using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class OutlineHandler : MonoBehaviour
{
    private Outline outline;
    private XRSimpleInteractable interactable;

    private void Awake() {
        outline = GetComponent<Outline>();
        interactable = GetComponent<XRSimpleInteractable>();
    }

    private void Start() {
        if (outline != null)
            outline.enabled = false;
    }

    private void OnEnable() {
        // Subscribe to hover events when the GameObject is enabled
        if (interactable != null) {
            interactable.hoverEntered.AddListener(OnHoverEntered);
            interactable.hoverExited.AddListener(OnHoverExited);

            // Ensure outline is disabled when the object is enabled (e.g., from pool)
            if (outline != null) {
                outline.enabled = false;
            }
        }
    }

    private void OnDisable() {
        // Unsubscribe from hover events when the GameObject is disabled
        if (interactable != null) {
            interactable.hoverEntered.RemoveListener(OnHoverEntered);
            interactable.hoverExited.RemoveListener(OnHoverExited);
        }
    }

    private void OnHoverEntered(HoverEnterEventArgs args) {
        // Enable the outline when hovered
        if (outline != null) {
            outline.enabled = true;
        }
    }

    private void OnHoverExited(HoverExitEventArgs args) {
        // Disable the outline when hover ends
        if (outline != null) {
            outline.enabled = false;
        }
    }
}