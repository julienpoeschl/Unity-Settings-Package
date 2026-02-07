using UnityEditor;
using UnityEngine;

namespace Settings
{
    /// <summary>
    /// Custom editor for `BoolSetting` making the `currentValue` property readonly and adding a button to set the default value as current value.
    /// </summary>
    [CustomEditor(typeof(BoolSetting))]
    public class BoolSettingEditor : Editor
    {
        private BoolSetting boolSetting;

        void OnEnable()
        {
            boolSetting = (BoolSetting)target;
        }

        public override void OnInspectorGUI()
        {
            SerializedProperty defaultValue = serializedObject.FindProperty("defaultValue");
            EditorGUILayout.PropertyField(defaultValue);

            EditorGUILayout.LabelField("Current Value", boolSetting.Value.ToString());

            SerializedProperty notify = serializedObject.FindProperty("notify");
            EditorGUILayout.PropertyField(notify);

            if (GUILayout.Button("Set Default"))
            {
                boolSetting.UseDefault();
            }
        }
    }
}
