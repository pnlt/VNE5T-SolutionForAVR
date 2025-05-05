using System;
using System.Collections.Generic;
using _Project.Scripts.Tests.Runtime.InteractiveFurniture;
using UnityEngine;

public class ModelListHandle : MonoBehaviour
{
    [SerializeField] private FurnitureHolder furnitureHolder;
    [SerializeField] private Model_Item itemPrefab;
    public FurnitureModification furnitureModification;

    private List<Furniture> furnitureList;

    private void SetFurnitureModification(FurnitureModification furnitureModification) {
        this.furnitureModification = furnitureModification;
    }

    private void Awake() {
        furnitureList = new();
    }

    private void OnEnable()
    {
        FurnitureModification.OnFurnitureReference += SetFurnitureModification;
    }

    private void Start() {
        furnitureList = furnitureHolder.furnitureDataList;
        InitializeList();
    }

    private void InitializeList() {
        var numberOfModels = furnitureList.Count;
        for (int i = 0; i < numberOfModels; i++) {
            var modelItem = Instantiate(itemPrefab, transform);
            modelItem.gameObject.name = furnitureList[i].Name + "Item";

            modelItem.InitializeItem(furnitureList[i]);
        }
    }

    private void OnDisable()
    {
        FurnitureModification.OnFurnitureReference -= SetFurnitureModification;   
    }
}