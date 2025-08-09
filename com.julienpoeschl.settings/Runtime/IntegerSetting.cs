using System;
using UnityEngine;

namespace Settings
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(fileName = "Setting", menuName = "Setting/Integer")]
    public class IntegerSetting : GenericSetting<int>
    {
        [SerializeField] private IntegerRange limit;
        public IntegerRange Limit => limit;

        public override void SetValue(int newValue)
        {
            if (limit.Min > newValue || limit.Max < newValue)
            {
                Debug.LogError("The new value: " + newValue + " of setting: " + name + " was outside of the limit and therefore discarded.");
                return;
            }
            base.SetValue(newValue);
        }

        [Serializable]
        public struct IntegerRange
        {
            public int Min;
            public int Max;
        }

    }
}


