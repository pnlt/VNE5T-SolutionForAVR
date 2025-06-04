using System;
using _Project.Scripts.Tests.Runtime.DesignPattern.ObjectPooling;
using UnityEngine;

namespace _Project.Scripts.Tests.Runtime.InteractiveFurniture
{
    public class TableModification : MonoBehaviour, IFurnitureSwap
    {
        private FurniturePooling<Table> tablePool;
        private Table _ownedTable;

        private void Awake() {
            _ownedTable = GetComponent<Table>();
        }

        private void Start() {
            tablePool = PoolManager.Instance.GetPool<Table>();
        }

        public void SetFurnitureReference() {
            EventBus<GetFurnitureSwap>.Raise(new GetFurnitureSwap(this));
        }

        public void Swap(Furniture newFurniture) {
            // TODO - Swap respective type of Furniture    
            var swappedTable = tablePool.GetObjectPooling<Table>(newFurniture);

            tablePool.ReturnObjectPooling(_ownedTable);
            swappedTable.transform.position = transform.position;
            swappedTable.transform.rotation = transform.rotation;
        }
    }
}