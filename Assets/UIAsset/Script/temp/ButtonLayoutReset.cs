using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace SGA.Temp
{
    public class ButtonLayoutSet : MonoBehaviour
    {
        void Start()
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(transform as RectTransform);

        }
    }
}