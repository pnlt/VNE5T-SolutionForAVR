using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SwappableObject : MonoBehaviour
{
    public GameObject initialPrefab; // Initial model to display
    public GameObject[] availablePrefabs; // Optional: for multiple swap options

    private void Start() {
        if (initialPrefab != null) {
            SwapModel(initialPrefab); // Set up the initial model
        }
    }

    // Swap the current model with a new one
    public void SwapModel(GameObject newPrefab) {
        // Deactivate the current model if it exists
        if (transform.childCount > 0) {
            Transform currentModel = transform.GetChild(0);
            currentModel.gameObject.SetActive(false); // Return to pool
        }

        // Get a new model from the pool
        GameObject newModel = PoolManager.Instance.GetFromPool(newPrefab);

        // Parent the new model to the holder
        newModel.transform.SetParent(transform);
        newModel.transform.localPosition = Vector3.zero; // Same position
        newModel.transform.localRotation = Quaternion.identity; // Same rotation

        // Set up the XR Simple Interactable event dynamically
        XRSimpleInteractable interactable = newModel.GetComponent<XRSimpleInteractable>();
        if (interactable != null) {
            // Clear any existing Select Entered events (to avoid duplicates)
            interactable.selectEntered.RemoveAllListeners();

            // Add a new listener that calls SwapModel on THIS SwappableObject (the scene instance)
            interactable.selectEntered.AddListener(args =>
                SwapModel(newPrefab == initialPrefab ? availablePrefabs[0] : initialPrefab));
        }

        // Activate the new model
        newModel.SetActive(true);
    }

    // Optional: Swap by index for multiple models
    public void SwapToModelByIndex(int index) {
        if (index >= 0 && index < availablePrefabs.Length) {
            SwapModel(availablePrefabs[index]);
        }
    }
}