using _Project.Scripts.Tests.Runtime.InteractiveFurniture;
using _Project.Scripts.Tests.Runtime.UI_Interactor;
using UnityEngine;
using UnityEngine.UI;

public class Model_Item : MonoBehaviour
{
    public Image modelImg;
    public ModelNameTxt name;
    
    public Furniture furnitureOwnership;
    
    public void InitializeItem(Furniture furniture)
    {
        furnitureOwnership = furniture;
    }
}
