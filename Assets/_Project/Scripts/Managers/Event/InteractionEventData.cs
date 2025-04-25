using UnityEngine;

/// <summary>
/// Data structure for interaction events
/// </summary>
public readonly struct InteractionEventData
{
    public readonly string InteractableId;
    public readonly GameObject Source;

    public InteractionEventData(string id, GameObject source) {
        InteractableId = id;
        Source = source;
    }
}