using SGA.UI;
using UnityEngine;

namespace SGA.Data
{
    [RequireComponent(typeof(InteractionWithScriptableObject))]
    public class BackupScriptableObject : MonoBehaviour
    {
        [SerializeField] SliderNToggle backupObject;
        [SerializeField] ComplexWindow complexWindow;

        InteractionWithScriptableObject interactComponent;

        private void Awake()
        {
            interactComponent = GetComponent<InteractionWithScriptableObject>();
            interactComponent.backupAction += GetData;
            complexWindow.dataReroll += OverlapData;

        }

        public void GetData()
        {
            backupObject.CopyValue(interactComponent.SliderNToggleObject);
        }
        public void OverlapData()
        {
            interactComponent.SliderNToggleObject.CopyValue(backupObject);
        }
        private void OnValidate()
        {
            interactComponent = GetComponent<InteractionWithScriptableObject>();

            Transform tempWindowTransform = transform.parent;
            while (complexWindow == null && tempWindowTransform != null)
            {
                if (tempWindowTransform.TryGetComponent(out ComplexWindow _window))
                {
                    complexWindow = _window;
                }
                tempWindowTransform = tempWindowTransform.parent;
            }
        }
    }
}
