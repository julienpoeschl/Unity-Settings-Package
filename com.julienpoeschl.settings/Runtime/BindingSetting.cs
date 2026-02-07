using UnityEngine;
using UnityEngine.InputSystem;

namespace Settings
{
    /// <summary>
    /// Scriptable object setting for a binding (custom struct `BindingData`).
    /// 
    /// The `SetValue` method is overwritten to check if the new value satisfies the expected properties.
    /// 
    /// Note: `BindingSetting` is not fully implemented yet.
    /// </summary>
    [CreateAssetMenu(fileName = "BindingSetting", menuName = "Settings/Binding")]
    public class BindingSetting : GenericSetting<BindingData>
    {
        [SerializeField] private InputActionReference action;

        /// <summary>
        /// Setter that only accepts values satisfying the expected properties of this setting.
        /// </summary>
        /// <param name="newValue"></param>
        public override void SetValue(BindingData newValue)
        {
            if (newValue.Path == string.Empty)
            {
                Debug.LogError("The new value: " + newValue + " of setting: " + name + " was outside of the limit and therefore discarded.");
                return;
            }

            base.SetValue(newValue);

            action.action.ApplyBindingOverride(newValue.Index, new InputBinding
            {
                overridePath = newValue.Path
            });
        }
    }

    [System.Serializable]
    public struct BindingData
    {
        public int Index;
        public string Path;
    }

}