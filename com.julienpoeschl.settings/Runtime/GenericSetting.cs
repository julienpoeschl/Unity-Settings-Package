using System;
using UnityEditor;
using UnityEngine;

namespace Settings
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class GenericSetting<T> : ScriptableObject
    {
        [SerializeField] private T defaultValue;

        [Header("Debugging")]
        [SerializeField] private bool notify;


        private T setValue = default;
        public T Value { get { return setValue; } }

        public event Action<T> OnValueChanged;

        protected const string MENU_BASE = "Settings";


        protected virtual void OnEnable()
        {
#if UNITY_EDITOR
            EditorApplication.playModeStateChanged += OnPlayModeChanged;
#endif
        }

        protected virtual void OnDisable()
        {
#if UNITY_EDITOR
            EditorApplication.playModeStateChanged -= OnPlayModeChanged;
#endif
        }

#if UNITY_EDITOR
        private void OnPlayModeChanged(PlayModeStateChange state)
        {
            if (state == PlayModeStateChange.ExitingPlayMode)
            {
                ClearAllListeners();
            }
        }
#endif

        public virtual void SetValue(T newValue)
        {
            if (notify) Debug.Log("The Setting: " + name + " was changed from " + setValue + " to " + newValue + ".");
            setValue = newValue;
            OnValueChanged?.Invoke(setValue);
        }

        public T UseDefault()
        {
            SetValue(defaultValue);
            return setValue;
        }

        public void ClearAllListeners()
        {
            OnValueChanged = null;
        }
    }
}
