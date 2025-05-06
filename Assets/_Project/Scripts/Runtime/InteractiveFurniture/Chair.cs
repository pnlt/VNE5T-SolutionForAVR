using System;
using _Project.Scripts.Tests.Runtime.InteractiveFurniture;
using _Project.Scripts.Tests.Runtime.ScriptableObject;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Chair : Furniture
{
    [SerializeField] private ChairData chairData;

    public override FurnitureData FurnitureData()
    {
        return chairData;
    }

    public override void LoadData(FurnitureData furnitureData)
    {
        
    }

}
