using UnityEngine;

namespace _Project.Scripts.Tests.Runtime.ScriptableObject
{
    public class FurnitureData : UnityEngine.ScriptableObject
    {
        [Tooltip( "Name of furniture" )]
        [SerializeField] private string name;
    
        [Tooltip( "Material of furniture (wood, steel, ...)" )]
        [SerializeField] public string material;
    
        [Tooltip( "Price of furniture" )]
        [SerializeField] private string price;

        [SerializeField] private Sprite illustrativeImg;
        

        public virtual void DisplayData(ref string name, ref string material, ref string price, ref Sprite illustrativeImg)
        {
            name = this.name;
            material = this.material;
            price = this.price;
            illustrativeImg = this.illustrativeImg;
        }
    }
}