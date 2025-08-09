using UnityEngine;
using UnityEngine.InputSystem;

namespace Settings
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(fileName = "Setting", menuName = "Setting/Binding")]
    public class BindingSetting : GenericSetting<BindingData>
    {
        [SerializeField] private InputActionReference action;

        public override void SetValue(BindingData newValue)
        {
            if (newValue == null)
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
    public class BindingData
    {
        public int Index;
        public string Path;
    }

}