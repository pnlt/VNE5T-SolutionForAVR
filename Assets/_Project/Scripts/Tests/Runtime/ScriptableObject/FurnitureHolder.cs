using System.Collections.Generic;
using _Project.Scripts.Tests.Runtime.InteractiveFurniture;
using UnityEngine;

[CreateAssetMenu( fileName = "Holder", menuName = "Furniture/FurnitureHolder", order = 0 )]
public class FurnitureHolder : ScriptableObject
{
    public List<Furniture> furnitureDataList;   
}


