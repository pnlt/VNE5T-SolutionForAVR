using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance { get; private set; }

    [System.Serializable]
    public class PoolConfig
    {
        public GameObject prefab; 
        public int poolSize;      
    }

    public List<PoolConfig> poolConfigs; 

    private Dictionary<GameObject, List<GameObject>> pools = new Dictionary<GameObject, List<GameObject>>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        InitializePools();
    }

    private void InitializePools()
    {
        foreach (var config in poolConfigs)
        {
            GameObject prefab = config.prefab;
            int poolSize = config.poolSize;
            List<GameObject> pool = new List<GameObject>();

            for (int i = 0; i < poolSize; i++)
            {
                GameObject obj = Instantiate(prefab);
                obj.SetActive(false); // Keep inactive until needed
                pool.Add(obj);
            }

            pools[prefab] = pool;
        }
    }

    // Retrieve an inactive GameObject from the pool
    public GameObject GetFromPool(GameObject prefab)
    {
        if (pools.TryGetValue(prefab, out List<GameObject> pool))
        {
            foreach (var obj in pool)
            {
                if (!obj.activeInHierarchy)
                {
                    return obj; 
                }
            }
            GameObject newObj = Instantiate(prefab);
            pool.Add(newObj);
            return newObj;
        }
        else
        {
            // If no pool exists for this prefab, create one
            GameObject newObj = Instantiate(prefab);
            List<GameObject> newPool = new List<GameObject> { newObj };
            pools[prefab] = newPool;
            return newObj;
        }
    }
}
