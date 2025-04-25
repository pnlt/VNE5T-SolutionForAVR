using System.Collections.Generic;
using _Project.Scripts.Tests.Runtime.InteractiveFurniture;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace _Project.Scripts.Tests.Runtime.DesignPattern.ObjectPooling
{
    public class ObjectPooling<T> where T : Component
    {
        //private T prefabs;
        private GameObject poolManager;
        
        private Dictionary<Furniture, List<T>> poolObjects;
        private GameObject typePooling;
        
        public ObjectPooling()
        {
            poolObjects = new();
            poolManager = GameObject.FindGameObjectWithTag("Pooling");
        }

        public T GetObjectPooling(Furniture furniture, T prefab)
        {
            if (poolObjects.Count == 0)
            {
                typePooling = new GameObject(typeof(T).FullName + "Pooling");
                typePooling.transform.SetParent(poolManager.transform);
            }
            
            T retrievedGO = null;
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
                poolObjects.Add(furniture, new List<T>());;
            }
            
            if (retrievedGO == null)
            {
                retrievedGO = SpawnObjectPooling(furniture, prefab);
            }

            return retrievedGO;
        }

        private T SpawnObjectPooling(Furniture furniture, T prefab)
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

