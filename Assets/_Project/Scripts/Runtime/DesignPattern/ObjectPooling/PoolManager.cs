using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Tests.Runtime.DesignPattern.ObjectPooling
{
    public class PoolManager : MonoBehaviour
    {
        private static PoolManager instance;
        private Dictionary<Type, object> poolObjects = new();
        
        public static PoolManager Instance => instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(instance);
            }
        }

        public ObjectPooling<T> GetPool<T>() where T : Component
        {
            var key = typeof(T);
            if (!poolObjects.TryGetValue(key, out var value))
            {
                poolObjects.Add(typeof(T), new ObjectPooling<T>());
            }
            
            return poolObjects[key] as ObjectPooling<T>;
        }
    }
}