using _Project.Scripts.Tests.Runtime.InteractiveFurniture;
using UnityEngine;

public struct GetFurnitureSwap : IEvent
{
    public IFurnitureSwap furnitureSwap;
    public GetFurnitureSwap(IFurnitureSwap furnitureSwap) {
        this.furnitureSwap = furnitureSwap;
    }
}

public class ItemEvent : MonoBehaviour
{
    private IFurnitureSwap furnitureModification;
    private Model_Item item;
    private EventBinding<GetFurnitureSwap> getFurnitureEvent;


    private void Awake() {
        item = GetComponent<Model_Item>();
        getFurnitureEvent = new EventBinding<GetFurnitureSwap>(SetFurnitureModification);
    }

    private void OnEnable() {
        EventBus<GetFurnitureSwap>.Register(getFurnitureEvent);
    }

    private void SetFurnitureModification(GetFurnitureSwap furnitureModification) {
        this.furnitureModification = furnitureModification.furnitureSwap;
    }

    public void OnClicked() {
        furnitureModification.Swap(item.furniture);
    }

    private void OnDisable() {
        EventBus<GetFurnitureSwap>.Deregister(getFurnitureEvent);
    }
}