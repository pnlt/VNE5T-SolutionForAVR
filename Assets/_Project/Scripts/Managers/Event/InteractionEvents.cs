using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using R3;
using System;

/// <summary>
/// Central event hub that manages interaction observables
/// </summary>
public class InteractionEvents : MonoBehaviour
{
    // Singleton pattern
    public static InteractionEvents Instance { get; private set; }

    // Observable subjects for different interaction events
    private Subject<InteractionEventData> _activateSubject = new();
    private Subject<InteractionEventData> _deactivateSubject = new();
    private Subject<InteractionEventData> _hoverEnterSubject = new();
    private Subject<InteractionEventData> _hoverExitSubject = new();

    // Public observables
    public Observable<InteractionEventData> OnActivate => _activateSubject;
    public Observable<InteractionEventData> OnDeactivate => _deactivateSubject;
    public Observable<InteractionEventData> OnHoverEnter => _hoverEnterSubject;
    public Observable<InteractionEventData> OnHoverExit => _hoverExitSubject;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    // Methods to publish events
    public void PublishActivate(string id, GameObject source) =>
        _activateSubject.OnNext(new InteractionEventData(id, source));

    public void PublishDeactivate(string id, GameObject source) =>
        _deactivateSubject.OnNext(new InteractionEventData(id, source));

    public void PublishHoverEnter(string id, GameObject source) =>
        _hoverEnterSubject.OnNext(new InteractionEventData(id, source));

    public void PublishHoverExit(string id, GameObject source) =>
        _hoverExitSubject.OnNext(new InteractionEventData(id, source));

    private void OnDestroy() {
        // Dispose subjects when destroyed
        _activateSubject.Dispose();
        _deactivateSubject.Dispose();
        _hoverEnterSubject.Dispose();
        _hoverExitSubject.Dispose();
    }
}