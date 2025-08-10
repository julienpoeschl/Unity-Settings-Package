using UnityEngine;
using UnityEngine.UI;

namespace Settings
{
    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(Slider))]
    public class IntegerSettingSliderUI : MonoBehaviour
    {
        [SerializeField] private IntegerSetting integerSetting;

        private Slider slider;

        void Awake()
        {
            slider = GetComponent<Slider>();
            slider.maxValue = integerSetting.Limit.Max;
            slider.minValue = integerSetting.Limit.Min;
            slider.wholeNumbers = true;
        }

        private void OnEnable()
        {
            slider.value = integerSetting.Value;
            slider.onValueChanged.AddListener(value => { integerSetting.SetValue((int)value); });
            integerSetting.OnValueChanged += value => slider.value = value;
        }

        void OnDisable()
        {
            slider.onValueChanged.RemoveListener(value => { integerSetting.SetValue((int)value); });
            integerSetting.OnValueChanged -= value => slider.value = value;
        }
    }
}
