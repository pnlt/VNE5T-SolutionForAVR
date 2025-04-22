using System;
using _Project.Scripts.Tests.Runtime.InteractiveFurniture;
using UnityEngine;
using UnityEngine.InputSystem;

public class Chair : Furniture
{
    public override Furniture GetAvailableFurniture()
    {
        return this;
    }
}
