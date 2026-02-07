using UnityEngine;

namespace Settings
{
    /// <summary>
    /// Scriptable object setting for a float.
    /// 
    /// Has new property `limit` which limits the allowed for the value of the setting to the range of given min and max.
    /// 
    /// The `SetValue` method is overwritten to check if the new value satisfies the limit.
    /// </summary>
    [CreateAssetMenu(fileName = "FloatSetting", menuName = "Settings/Float")]
    public class FloatSetting : GenericSetting<float>
    {
        [SerializeField] private Range<float> limit;
        public Range<float> Limit => limit;

        /// <summary>
        /// Setter that only accepts values satisfying the float limit of this setting.
        /// </summary>
        /// <param name="newValue"></param>
        public override void SetValue(float newValue)
        {
            if (limit.Min > newValue || limit.Max < newValue)
            {
                Debug.LogError("The new value: " + newValue + " of setting: " + name + " was outside of the limit and therefore discarded.");
                return;
            }

            base.SetValue(newValue);
        }
    }
}
