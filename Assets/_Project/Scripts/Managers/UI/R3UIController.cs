using System.Collections.Generic;
using R3;
using UnityEngine;

/// <summary>
/// Controls UI visibility based on interaction events
/// </summary>
public class R3UIController : MonoBehaviour
{
    [System.Serializable]
    public class InteractableUIMapping
    {
        public string interactableId;
        public Canvas uiCanvas;
    }

    [SerializeField] private List<InteractableUIMapping> uiMappings = new();
    [SerializeField] private bool hideUIOnDeactivate = true;

    private CompositeDisposable _disposables;
    private Dictionary<string, Canvas> _idToCanvasMap;

    private void Awake() {
        _disposables = new CompositeDisposable();
        _idToCanvasMap = new Dictionary<string, Canvas>();

        // Build lookup dictionary for performance
        foreach (var mapping in uiMappings) {
            if (mapping.uiCanvas != null) {
                mapping.uiCanvas.enabled = false;
                _idToCanvasMap[mapping.interactableId] = mapping.uiCanvas;
            }
        }
    }

    private void OnEnable() {
        if (InteractionEvents.Instance == null) {
            return;
        }


        // Subscribe to activation events
        InteractionEvents.Instance.OnActivate
            .Where(data => _idToCanvasMap.ContainsKey(data.InteractableId))
            .Subscribe(data => { _idToCanvasMap[data.InteractableId].enabled = true; })
            .AddTo(_disposables);

        // Subscribe to deactivation events if needed
        if (hideUIOnDeactivate) {
            InteractionEvents.Instance.OnDeactivate
                .Where(data => _idToCanvasMap.ContainsKey(data.InteractableId))
                .Subscribe(data => { _idToCanvasMap[data.InteractableId].enabled = false; })
                .AddTo(_disposables);
        }
    }

    public void HideUI(string interactableId) {
        if (_idToCanvasMap.TryGetValue(interactableId, out Canvas canvas)) {
            canvas.enabled = false;
        }
    }

    private void OnDestroy() {
        _disposables.Dispose();
    }
}