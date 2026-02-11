using System;
using UnityEngine;

namespace Settings
{
    /// <summary>
    /// Scriptable object setting for an integer.
    /// 
    /// Has new property `limit` which limits the allowed for the value of the setting to the range of given min and max.
    /// 
    /// The `SetValue` method is overwritten to check if the new value satisfies the limit.
    /// </summary>
    [CreateAssetMenu(fileName = "IntegerSetting", menuName = "Settings/Integer")]
    public class IntegerSetting : GenericSetting<int>
    {
        [SerializeField] private Range<int> limit;
        public Range<int> Limit => limit;

        /// <summary>
        /// Setter that only accepts values satisfying the integer limit of this setting.
        /// </summary>
        /// <param name="newValue"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public override void SetValue(int newValue)
        {
            if (limit.Min > newValue || limit.Max < newValue)
            {
                if (notify) Debug.LogError("The new value: " + newValue + " of setting: " + name + " was outside of the limit and therefore discarded.");
                
                throw new ArgumentOutOfRangeException();
            }

            base.SetValue(newValue);
        }
    }
}


