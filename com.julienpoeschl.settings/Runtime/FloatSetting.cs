using System;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = "Setting", menuName = MENU_BASE + "/Float")]
    public class FloatSetting : GenericSetting<float>
    {
        [SerializeField] private FloatRange limit;
        public FloatRange Limit => limit;

        public override void SetValue(float newValue)
        {
            if (limit.Min > newValue || limit.Max < newValue)
            {
                Debug.LogError("The new value: " + newValue + " of setting: " + name + " was outside of the limit and therefore discarded.");
                return;
            }
            base.SetValue(newValue);
        }

        [Serializable]
        public struct FloatRange
        {
            public float Min;
            public float Max;
        }

    }
}
