using System;
using _Project.Scripts.Tests.Runtime.InteractiveFurniture;
using UnityEngine;

public class ItemEvent : MonoBehaviour
{
    [SerializeField] private FurnitureModification furnitureModification;
    private Model_Item item;


    private void Awake() {
        item = GetComponent<Model_Item>();
    }

    private void OnEnable() {
        FurnitureModification.OnFurnitureReference += SetFurnitureModification;
    }

    private void SetFurnitureModification(FurnitureModification furnituremodification) {
        this.furnitureModification = furnituremodification;
    }

    public void OnClicked() {
        furnitureModification.Swap(item.furniture);
        gameObject.SetActive(false);
    }

    private void OnDisable() {
        FurnitureModification.OnFurnitureReference -= SetFurnitureModification;
    }
}