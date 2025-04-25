using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class OutlineHandler : MonoBehaviour
{
    private Outline outline;
    private XRSimpleInteractable interactable;

    private void Awake() {
        outline = GetComponentInChildren<Outline>();
        interactable = GetComponent<XRSimpleInteractable>();
    }

    private void Start() {
        // Ensure the outline is disabled by default
        if (outline != null)
            outline.enabled = false;

        if (interactable != null) {
            interactable.hoverEntered.AddListener(OnHoverEntered);
            interactable.hoverExited.AddListener(OnHoverExited);
        }
    }


    private void OnHoverEntered(HoverEnterEventArgs args) {
        if (outline != null) {
            outline.enabled = true;
        }
    }

    private void OnHoverExited(HoverExitEventArgs args) {
        if (outline != null) {
            outline.enabled = false;
        }
    }
}