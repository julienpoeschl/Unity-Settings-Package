using System;

namespace Settings
{
    /// <summary>
    /// Struct that holds a minimum and maximum value. 
    /// </summary>
    /// <typeparam name="T">The type of the minimum and maximum value.</typeparam>
    [Serializable]
    public struct Range<T> where T : IComparable<T>
    {
        public T Min;
        public T Max;
    }
}
