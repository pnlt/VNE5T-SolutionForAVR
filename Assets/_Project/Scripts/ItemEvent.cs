using System;
using _Project.Scripts.Tests.Runtime.InteractiveFurniture;
using UnityEngine;

public class ItemEvent : MonoBehaviour
{
    [SerializeField] private FurnitureModification furnitureModification;
    private ModelListHandle modelListHandle;
    private Model_Item item;
    
    

    private void Awake()
    {
        item = GetComponent<Model_Item>();
        modelListHandle = GetComponentInParent<ModelListHandle>();
    }

    private void Start()
    {
        furnitureModification = modelListHandle.furnitureModification;
    }

    public void OnClicked()
    {
        furnitureModification.Swap(item.furniture);
    }
}