using _Project.Scripts.Tests.Runtime.ScriptableObject;
using UnityEngine;

namespace _Project.Scripts.Tests.Runtime.InteractiveFurniture
{
    public abstract class Furniture : MonoBehaviour
    {
        protected string name;
        protected string material;
        protected string price;
        protected Sprite illustrativeImg;

        public string Name => name;
        public Sprite Img => illustrativeImg;
        
        public abstract FurnitureData FurnitureData();

        public abstract void LoadData(FurnitureData furnitureData);
    }
}