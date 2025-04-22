using System.Collections.Generic;
using _Project.Scripts.Tests.Runtime.InteractiveFurniture;
using UnityEngine;

public class ModelListHandle : MonoBehaviour
{
    [SerializeField] private FurnitureHolder furnitureHolder;
    [SerializeField] private Model_Item itemPrefab;
    
    private List<Furniture> furnitureList;

    private void Awake()
    {
        furnitureList = new();
    }

    private void Start()
    {
        furnitureList = furnitureHolder.furnitureDataList;
    }

    private void InitializeList()
    {
        var numberOfModels = furnitureList.Count;
        for (int i = 0; i < numberOfModels; i++)
        {
            var modelItem = Instantiate(itemPrefab);
            
            modelItem.gameObject.name = furnitureList[i].Name + "Item";
            
            // TODO - Set Its appropriate parent transform
            
            modelItem.InitializeItem(furnitureList[i]);
        }
        
    }
}
