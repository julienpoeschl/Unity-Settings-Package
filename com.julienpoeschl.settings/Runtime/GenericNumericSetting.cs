using System;
using UnityEngine;

namespace Settings
{
    public abstract class GenericNumericSetting<T> : GenericSetting<T> where T : struct, IConvertible
    {

        [SerializeField] protected Range<int> limit;
        public Range<int> Limit => limit;

        public float FloatValue => Convert.ToSingle(Value);
    }
}
