using UnityEngine;

namespace _Project.Scripts.Tests.Runtime.ScriptableObject
{
    public class FurnitureData : UnityEngine.ScriptableObject
    {
        [Tooltip( "Name of furniture" )]
        [SerializeField] private string name;
    
        [Tooltip( "Material of furniture (wood, steel, ...)" )]
        [SerializeField] private string material;
    
        [Tooltip( "Price of furniture" )]
        [SerializeField] private string price;

        [SerializeField] private Sprite illustrativeImg;
        
        public string Name => name;
        public string Material => material;
        public string Price => price;
        public Sprite IllustrativeImg => illustrativeImg;
    }
}