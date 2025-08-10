using UnityEngine;
using UnityEngine.UI;

namespace Settings
{
    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(Toggle))]
    public class BoolSettingUI : MonoBehaviour
    {
        [SerializeField] private BoolSetting boolSetting;

        private Toggle toggle;

        void Awake()
        {
            toggle = GetComponent<Toggle>();
        }

        private void OnEnable()
        {
            toggle.isOn = boolSetting.Value;
            toggle.onValueChanged.AddListener(value => { boolSetting.SetValue(value); });
            boolSetting.OnValueChanged += value => toggle.isOn = value;
        }

        void OnDisable()
        {
            toggle.onValueChanged.RemoveListener(value => { boolSetting.SetValue(value); });
            boolSetting.OnValueChanged -= value => toggle.isOn = value;
        }
    }
}
