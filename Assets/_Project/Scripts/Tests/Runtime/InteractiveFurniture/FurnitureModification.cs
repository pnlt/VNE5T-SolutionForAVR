using System;
using _Project.Scripts.Tests.Runtime.DesignPattern.ObjectPooling;
using UnityEngine;

namespace _Project.Scripts.Tests.Runtime.InteractiveFurniture
{
    public class FurnitureModification : MonoBehaviour, IFurnitureSwap
    {
        private ObjectPooling<Chair> chairPool;
        private Chair _ownedChair;

        private void Awake()
        {
            _ownedChair = GetComponent<Chair>();
        }

        private void Start()
        {
            chairPool = PoolManager.Instance.GetPool<Chair>();
        }

        public void Swap(Furniture newFurniture)
        {
            // TODO - Swap respective type of Furniture    
            var swappedChair = chairPool.GetObjectPooling(newFurniture, newFurniture.GetComponent<Chair>());
            
            chairPool.ReturnObjectPooling(_ownedChair);
            swappedChair.transform.position = transform.position;
            swappedChair.transform.rotation = transform.rotation;
        }
    }
}
