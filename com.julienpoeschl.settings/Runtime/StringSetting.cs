using System;
using UnityEngine;

namespace Settings
{
    /// <summary>
    /// Scriptable object setting for a string.
    /// 
    /// Has new property `characterLimit` which limits the amount of characters allowed for the value of the setting.
    /// 
    /// The `SetValue` method is overwritten to check if the new value satisfies the character limit.
    /// </summary>
    [CreateAssetMenu(fileName = "StringSetting", menuName = "Settings/String")]
    public class StringSetting : GenericSetting<string>
    {
        [SerializeField] private Range<uint> characterLimit;
        public Range<uint> CharacterLimit => characterLimit;

        /// <summary>
        /// Setter that only accepts values satisfying the character limit of this setting.
        /// </summary>
        /// <param name="newValue"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public override void SetValue(string newValue)
        {
            if (characterLimit.Min > newValue.Length || characterLimit.Max < newValue.Length)
            {
                if (notify) Debug.LogError("The new value: " + newValue + " of setting: " + name + " was outside of the limit and therefore discarded.");
                
                throw new ArgumentOutOfRangeException();
            }

            base.SetValue(newValue);
        }
    }
}
