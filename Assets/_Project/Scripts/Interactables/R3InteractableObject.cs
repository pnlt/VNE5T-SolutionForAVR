using R3;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

/// <summary>
/// Attaches to interactable objects to broadcast interaction events
/// </summary>
public class R3InteractableObject : MonoBehaviour
{
    [SerializeField] private string interactableId;

    private XRSimpleInteractable _interactable;
    private Outline _outline;
    private CompositeDisposable _disposables;

    public string InteractableId => interactableId;

    private void Awake() {
        _interactable = GetComponent<XRSimpleInteractable>();
        _outline = GetComponentInChildren<Outline>();
        _disposables = new CompositeDisposable();

        if (_outline != null)
            _outline.enabled = false;
    }

    private void OnEnable() {
        if (_interactable != null) {
            _interactable.hoverEntered.AddListener(OnHoverEntered);
            _interactable.hoverExited.AddListener(OnHoverExited);
            _interactable.activated.AddListener(OnActivated);
            _interactable.deactivated.AddListener(OnDeactivated);
        }
    }

    private void OnDisable() {
        if (_interactable != null) {
            _interactable.hoverEntered.RemoveListener(OnHoverEntered);
            _interactable.hoverExited.RemoveListener(OnHoverExited);
            _interactable.activated.RemoveListener(OnActivated);
            _interactable.deactivated.RemoveListener(OnDeactivated);
        }
    }

    private void OnHoverEntered(HoverEnterEventArgs args) {
        if (_outline != null)
            _outline.enabled = true;

        InteractionEvents.Instance.PublishHoverEnter(interactableId, gameObject);
    }

    private void OnHoverExited(HoverExitEventArgs args) {
        if (_outline != null)
            _outline.enabled = false;

        InteractionEvents.Instance.PublishHoverExit(interactableId, gameObject);
    }

    private void OnActivated(ActivateEventArgs args) {
        InteractionEvents.Instance.PublishActivate(interactableId, gameObject);
    }

    private void OnDeactivated(DeactivateEventArgs args) {
        InteractionEvents.Instance.PublishDeactivate(interactableId, gameObject);
    }

    private void OnDestroy() {
        _disposables.Dispose();
    }
}