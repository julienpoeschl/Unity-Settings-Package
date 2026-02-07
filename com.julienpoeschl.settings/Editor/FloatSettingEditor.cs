using UnityEditor;
using UnityEngine;

namespace Settings
{
    /// <summary>
    /// Custom editor for `FloatSetting` handling min and max values of limit,
    /// using a slider from min to max for `defaultValue`,
    /// making the `currentValue` property readonly and
    /// adding a button to set the default value as current value.
    /// </summary>
    [CustomEditor(typeof(FloatSetting))]
    public class FloatSettingEditor : Editor
    {
        private FloatSetting floatSetting;

        void OnEnable()
        {
            floatSetting = (FloatSetting)target;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            SerializedProperty limit = serializedObject.FindProperty("limit");
            float min = limit.FindPropertyRelative("Min").floatValue;
            float max = limit.FindPropertyRelative("Max").floatValue;

            if (min > max) limit.FindPropertyRelative("Max").floatValue = min;

            EditorGUILayout.PropertyField(limit);

            // Draw the defaultValue as a slider with range limit.min to limit.max
            SerializedProperty defaultValue = serializedObject.FindProperty("defaultValue");
            defaultValue.floatValue = EditorGUILayout.Slider("Default Value", defaultValue.floatValue, min, max);

            EditorGUILayout.LabelField("Current Value", floatSetting.Value.ToString());

            SerializedProperty notify = serializedObject.FindProperty("notify");
            EditorGUILayout.PropertyField(notify);

            if (GUILayout.Button("Set Default"))
            {
                floatSetting.UseDefault();
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
