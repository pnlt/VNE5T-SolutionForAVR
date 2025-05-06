using _Project.Scripts.Tests.Runtime.InteractiveFurniture;
using _Project.Scripts.Tests.Runtime.UI_Interactor;
using UnityEngine;
using UnityEngine.UI;

public class Model_Item : MonoBehaviour
{
    public Image modelImg;
    public ModelNameTxt name;

    private Furniture furnitureOwnership;

    public Furniture furniture => furnitureOwnership;

    public void InitializeItem(Furniture furniture) {
        furnitureOwnership = furniture;
        modelImg.sprite = furniture.Img;
        name.SetModelName(furniture.Name);
    }
}