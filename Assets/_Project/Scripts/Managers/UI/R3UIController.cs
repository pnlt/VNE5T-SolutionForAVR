using System.Collections.Generic;
using _Project.Scripts.Tests.Runtime.InteractiveFurniture;
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
        public SkinnedMeshRenderer meshRenderer;
    }

    [SerializeField] private List<InteractableUIMapping> uiMappings = new();
    [SerializeField] private bool hideUIOnDeactivate = true;

    private CompositeDisposable _disposables;
    private Dictionary<string, InteractableUIMapping> _idToMappingMap;


    private void Awake() {
        _disposables = new CompositeDisposable();
        _idToMappingMap = new Dictionary<string, InteractableUIMapping>();

        // Build lookup dictionary for performance
        foreach (var mapping in uiMappings) {
            if (mapping.uiCanvas != null) {
                mapping.uiCanvas.enabled = false;

                // Also disable the mesh renderer if it exists
                if (mapping.meshRenderer != null) {
                    mapping.meshRenderer.enabled = false;
                }

                _idToMappingMap[mapping.interactableId] = mapping;
            }
        }
    }

    private void OnEnable() {
        if (InteractionEvents.Instance == null) {
            return;
        }

        // Subscribe to activation events
        InteractionEvents.Instance.OnActivate
            .Where(data => _idToMappingMap.ContainsKey(data.InteractableId))
            .Subscribe(data =>
            {
                var mapping = _idToMappingMap[data.InteractableId];
                mapping.uiCanvas.enabled = true;

                // Enable the mesh renderer if it exists
                if (mapping.meshRenderer != null) {
                    mapping.meshRenderer.enabled = true;
                }
            })
            .AddTo(_disposables);

        // Subscribe to deactivation events if needed
        if (hideUIOnDeactivate) {
            InteractionEvents.Instance.OnDeactivate
                .Where(data => _idToMappingMap.ContainsKey(data.InteractableId))
                .Subscribe(data =>
                {
                    var mapping = _idToMappingMap[data.InteractableId];
                    mapping.uiCanvas.enabled = false;
                    // Disable the mesh renderer if it exists
                    if (mapping.meshRenderer != null) {
                        mapping.meshRenderer.enabled = false;
                    }
                })
                .AddTo(_disposables);
        }
    }

    public void HideUI(string interactableId) {
        if (_idToMappingMap.TryGetValue(interactableId, out InteractableUIMapping mapping)) {
            mapping.uiCanvas.enabled = false;
            // Disable the mesh renderer if it exists
            if (mapping.meshRenderer != null) {
                mapping.meshRenderer.enabled = false;
            }
        }
    }

    private void OnDestroy() {
        _disposables.Dispose();
    }
}