using System;
using System.Collections.Generic;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace SGA.UI
{

    public class ComplexWindow : UIWindow
    {
        public ActionButton[] actionButtons;
        Dictionary<string, UnityEngine.UI.Button> keyButtonDictionary;
        public Action dataReroll { get; set; }

        public bool isChanged { get; set; }

        WindowManager windowManager;
        [SerializeField] string cancelPopupName = "SettingCancelPopup";
        UIWindow cancelPopup;
        private void Start()
        {
            windowManager = transform.parent.GetComponent<WindowManager>();
            cancelPopup = windowManager.transform.Find(cancelPopupName).GetComponent<UIWindow>();

            keyButtonDictionary = new Dictionary<string, UnityEngine.UI.Button>();
            int length = actionButtons.Length;

            for (int i = 0; i < length; i++)
            {
                keyButtonDictionary.Add(actionButtons[i].actionName, actionButtons[i].button);
            }
            VisibleAction += ChangeReset;
        }
#if ENABLE_INPUT_SYSTEM
        public override void ActionTrigger(in InputAction.CallbackContext callbackContext)
        {
            if (!callbackContext.started || !keyButtonDictionary.ContainsKey(callbackContext.action.name))
                return;

            keyButtonDictionary[callbackContext.action.name].onClick.Invoke();
        }
#endif
        public void DataReroll()
        {
            dataReroll();
            ChangeReset();
        }
        public void OnCancelButtonClicked()
        {
            if (!isChanged)
                windowManager.CloseWindow(this);
            else
            {
                windowManager.OpenWindow(cancelPopup);
            }

        }
        public void ChangeReset()
        {
            isChanged = false;
        }
    }
}
