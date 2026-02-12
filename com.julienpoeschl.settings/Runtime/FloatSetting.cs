using System;
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
    public class FloatSetting : GenericNumericSetting<float>
    {

        /// <summary>
        /// Setter that only accepts values satisfying the float limit of this setting.
        /// </summary>
        /// <param name="newValue"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public override void SetValue(float newValue)
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
