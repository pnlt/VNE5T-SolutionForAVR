using UnityEngine;
using _Project.Scripts.Tests.Runtime.InteractiveFurniture;
using _Project.Scripts.Tests.Runtime.ScriptableObject;

public class Table : Furniture
{
    
    [SerializeField] private TableData tableData;

    public override FurnitureData FurnitureData()
    {
        return tableData;
    }

    public override void LoadData(FurnitureData furnitureData)
    {
        
    }

}
