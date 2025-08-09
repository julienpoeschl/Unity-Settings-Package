using UnityEditor;
using UnityEngine;

//[CustomEditor(typeof(SettingsManager))]
public class SettingsManagerEditor : Editor
{
    SerializedProperty defaultControlsSettings;
    SerializedProperty defaultAccessibilitySettings;
    SerializedProperty defaultGraphicsSettings;
    SerializedProperty defaultVolumeSettings;
    SerializedProperty[] defaultSettings;

    void OnEnable()
    {
        defaultControlsSettings = serializedObject.FindProperty("defaultControlsSettings");
        defaultAccessibilitySettings = serializedObject.FindProperty("defaultAccessibilitySettings");
        defaultGraphicsSettings = serializedObject.FindProperty("defaultGraphicsSettings");
        defaultVolumeSettings = serializedObject.FindProperty("defaultVolumeSettings");
        defaultSettings = new SerializedProperty[]
        {
            defaultControlsSettings, defaultAccessibilitySettings, defaultGraphicsSettings, defaultVolumeSettings
        };
    }

    void OnDisable()
    {
        
    }


    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        DrawSettingsGroup("General Settings", defaultSettings[0]);
        DrawSettingsGroup("Camera Settings", defaultSettings[1]);
        DrawSettingsGroup("Audio Settings", defaultSettings[2]);
        DrawSettingsGroup("Video Settings", defaultSettings[3]);

        serializedObject.ApplyModifiedProperties();
    }

    void DrawSettingsGroup(string label, SerializedProperty prop)
    {
        if (prop == null || prop.objectReferenceValue == null) return;

        EditorGUILayout.BeginVertical("box");
        EditorGUILayout.LabelField(label, EditorStyles.boldLabel);

        EditorGUILayout.PropertyField(prop);
        Editor editor = CreateEditor(prop.objectReferenceValue);
        if (editor != null)
        {
            editor.OnInspectorGUI();
        }

        EditorGUILayout.EndVertical();
        EditorGUILayout.Space(10);
    }
}
