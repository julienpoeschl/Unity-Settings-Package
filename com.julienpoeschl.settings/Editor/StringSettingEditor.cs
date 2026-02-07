using UnityEditor;
using UnityEngine;

namespace Settings
{
    /// <summary>
    /// Custom editor for `StringSetting` handling min and max values of character limit,
    /// using a slider from min to max for `defaultValue`,
    /// making the `currentValue` property readonly and
    /// adding a button to set the default value as current value.
    /// </summary>
    [CustomEditor(typeof(StringSetting))]
    public class StringSettingEditor : Editor
    {
        private StringSetting stringSetting;

        void OnEnable()
        {
            stringSetting = (StringSetting)target;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            SerializedProperty limit = serializedObject.FindProperty("characterLimit");
            int min = limit.FindPropertyRelative("Min").intValue;
            int max = limit.FindPropertyRelative("Max").intValue;

            if (min > max) limit.FindPropertyRelative("Max").intValue = min;

            EditorGUILayout.PropertyField(limit);

            SerializedProperty defaultValue = serializedObject.FindProperty("defaultValue");

            // If the string for `defaultValue` doesn't satisfy the maximum length, it's truncated after editing the text field.
            // Checks for string mimimum length only apply on set.
            EditorGUI.BeginChangeCheck();
            string value = EditorGUILayout.TextField("Default Value", defaultValue.stringValue);
            if (EditorGUI.EndChangeCheck())
            {
                if (value.Length > max)
                    value = value[..max];

                defaultValue.stringValue = value;
            }

            EditorGUILayout.LabelField("Current Value", stringSetting.Value);

            SerializedProperty notify = serializedObject.FindProperty("notify");
            EditorGUILayout.PropertyField(notify);

            if (GUILayout.Button("Set Default"))
            {
                stringSetting.UseDefault();
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
