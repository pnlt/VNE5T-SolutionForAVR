using _Project.Scripts.Tests.Runtime.DesignPattern.ObjectPooling;
using _Project.Scripts.Tests.Runtime.InteractiveFurniture;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    public Model_Item chair;

    public Chair originalChair;
    private PoolManager poolManager;


    private void Start() {
    }

    private void Update() {
        if (Keyboard.current.aKey.wasPressedThisFrame) {
            //originalChair.GetComponent<FurnitureModification>().Swap(chair.furnitureOwnership);
        }
    }
}