using SGA.UI;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace SGA.Editors
{

    [CustomEditor(typeof(WindowDraggable))]
    public class DraggableEditor : Editor
    {
        SerializedProperty image;

        private void OnEnable()
        {
            image = serializedObject.FindProperty("image");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            WindowDraggable draggable = (WindowDraggable)target;

            if (draggable.DragAreaDetermineByAlpha)
            {
                EditorGUILayout.PropertyField(image, new GUIContent("image"));
                serializedObject.ApplyModifiedProperties();
            }

        }

    }

}