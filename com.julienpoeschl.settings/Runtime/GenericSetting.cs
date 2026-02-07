using System;
using UnityEditor;
using UnityEngine;

namespace Settings
{
    /// <summary>
    /// Abstract base scriptable object for a generic setting of type T.
    /// </summary>
    /// <typeparam name="T">The type of the setting.</typeparam>
    public abstract class GenericSetting<T> : ScriptableObject
    {
        [Tooltip("The default value of the setting. Will be used as fallback value.")]
        [SerializeField] private T defaultValue;

        [Tooltip("Turn on notification about value changes.")]
        [Header("Debugging")]
        [SerializeField] private bool notify;


        private T setValue = default;
        public T Value { get { return setValue; } }

        /// <summary>
        /// Called on every successful value change.
        /// </summary>
        public event Action<T> OnValueChanged;


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
            if (notify) Debug.Log("The Setting: {" + name + "} was changed from {" + setValue + "} to {" + newValue + "}.");
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
