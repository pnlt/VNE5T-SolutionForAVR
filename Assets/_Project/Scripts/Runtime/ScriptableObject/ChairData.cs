using UnityEngine;

namespace _Project.Scripts.Tests.Runtime.ScriptableObject
{
    [CreateAssetMenu( fileName = "ChairData", menuName = "Furniture/Specification/ChairData", order = 0 )]
    public class ChairData : FurnitureData
    {
        public override void DisplayData(ref string name, ref string material, ref string price, ref Sprite illustrativeImg)
        {
            base.DisplayData(ref name, ref material, ref price, ref illustrativeImg);
            Debug.Log("Dumatuimay");
        }
    }
}