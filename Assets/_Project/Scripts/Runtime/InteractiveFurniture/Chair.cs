using System;
using _Project.Scripts.Tests.Runtime.InteractiveFurniture;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Chair : Furniture
{
    public override Furniture GetAvailableFurniture()
    {
        return this;
    }

    private void Start() {
        
        SetData();
    }
    void SetData()
    {
        furnitureData.DisplayData(ref name, ref material, ref price, ref illustrativeImg);

    }
}
