using System;
using System.Collections.Generic;
using _Project.Scripts.Tests.Runtime.InteractiveFurniture;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace _Project.Scripts.Tests.Runtime.DesignPattern.ObjectPooling
{
    public class FurniturePooling<T> where T : Component
    {
        private GameObject poolManager;
        
        private Dictionary<Type, List<Furniture>> poolObjects;
        private GameObject typePooling;
        
        public FurniturePooling()
        {
            poolObjects = new();
            poolManager = GameObject.FindGameObjectWithTag("Pooling");
        }

        public Furniture GetObjectPooling<TFurniture>(Furniture prefab) where TFurniture : T
        {
            var furniture = typeof(TFurniture);
            if (!poolObjects.ContainsKey(furniture))
            {
                typePooling = new GameObject(typeof(T).FullName + "Pooling");
                typePooling.transform.SetParent(poolManager.transform);
            }
            
            Furniture retrievedGO = null;
            if (poolObjects.TryGetValue(furniture, out var listObj))
            {
                foreach (var @object in listObj)
                {
                    if (!@object.gameObject.activeSelf)
                    {
                        retrievedGO = @object;
                        retrievedGO.gameObject.SetActive(true);
                        break;
                    }
                }
            }
            else
            {
                poolObjects.Add(furniture, new List<Furniture>());;
            }
            
            if (retrievedGO == null)
            {
                retrievedGO = SpawnObjectPooling(furniture, prefab);
            }

            return retrievedGO;
        }

        private Furniture SpawnObjectPooling(Type furniture, Furniture prefab)
        {
            var newGO = Object.Instantiate(prefab, typePooling.transform);
            newGO.name = prefab.name;
            poolObjects[furniture].Add(newGO);
            
            return newGO;
        }

        public void ReturnObjectPooling(T obj)
        {
            obj.gameObject.SetActive(false);
        }
    }
}

