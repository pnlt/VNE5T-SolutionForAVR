using System;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.Tests.Runtime.UI_Interactor
{
    public class ModelNameTxt : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI modelName;

        private void Awake() {
            modelName = GetComponent<TextMeshProUGUI>();
        }

        public void SetModelName(string name)
        {
            modelName.text = name;
        }
    }
}