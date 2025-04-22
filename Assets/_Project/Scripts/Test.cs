using _Project.Scripts.Tests.Runtime.DesignPattern.ObjectPooling;
using _Project.Scripts.Tests.Runtime.InteractiveFurniture;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    public Model_Item chair;
    public Model_Item table;

    public Chair originalChair;
    private ObjectPooling<Chair> chairPool;
    private PoolManager poolManager;
    

    private void Start()
    {
        chairPool = PoolManager.Instance.GetPool<Chair>();
    }

    private void Update()
    {
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            var chair = chairPool.GetObjectPooling(this.chair.furnitureOwnership, this.chair.furnitureOwnership.GetComponent<Chair>());
        }

        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            var chair = chairPool.GetObjectPooling(this.table.furnitureOwnership, this.table.furnitureOwnership.GetComponent<Chair>());
        }
    }
}
