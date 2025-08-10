using UnityEngine;
using TMPro;

namespace Settings
{
    [RequireComponent(typeof(TMP_Dropdown))]
    public class IntegerSettingDropdownUI : MonoBehaviour
    {
        [SerializeField] private IntegerSetting integerSetting;

        private TMP_Dropdown dropdown;

        void Awake()
        {
            dropdown = GetComponent<TMP_Dropdown>();
        }

        private void OnEnable()
        {
            dropdown.value = integerSetting.Value;
            dropdown.onValueChanged.AddListener(value => { integerSetting.SetValue((int)value); });
        }

        void OnDisable()
        {
            dropdown.onValueChanged.RemoveListener(value => { integerSetting.SetValue((int)value); });
        }
    }
}
