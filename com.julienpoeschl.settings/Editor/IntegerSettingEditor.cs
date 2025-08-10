using UnityEditor;
using UnityEngine;

namespace Settings
{
    [CustomEditor(typeof(IntegerSetting))]
    public class IntegerSettingEditor : Editor
    {
        private IntegerSetting integerSetting;
        void OnEnable()
        {
            integerSetting = (IntegerSetting)target;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            SerializedProperty limit = serializedObject.FindProperty("limit");
            int min = limit.FindPropertyRelative("Min").intValue;
            int max = limit.FindPropertyRelative("Max").intValue;

            if (min > max) limit.FindPropertyRelative("Max").intValue = min;

            EditorGUILayout.PropertyField(limit);

            // Draw the defaultValue as a slider with range limit.min to limit.max
            SerializedProperty defaultValue = serializedObject.FindProperty("defaultValue");
            defaultValue.intValue = (int)EditorGUILayout.Slider("Default Value", defaultValue.intValue, min, max);

            EditorGUILayout.LabelField("Current Value", integerSetting.Value.ToString());

            SerializedProperty notify = serializedObject.FindProperty("notify");
            EditorGUILayout.PropertyField(notify);

            if (GUILayout.Button("Set Default"))
            {
                integerSetting.UseDefault();
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
