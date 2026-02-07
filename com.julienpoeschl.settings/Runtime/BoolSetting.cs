using UnityEngine;

namespace Settings
{
    /// <summary>
    /// Scriptable object setting for a boolean.
    /// Since all functionality needed is already present by providing the base class `GenericSetting` with the bool type, this class is empty.
    /// </summary>
    [CreateAssetMenu(fileName = "BoolSetting", menuName = "Settings/Bool")]
    public class BoolSetting : GenericSetting<bool>
    {
        
    }
}

