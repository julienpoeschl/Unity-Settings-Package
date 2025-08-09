using UnityEngine;
using UnityEngine.UI;

namespace Settings
{
    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(Slider))]
    public class FloatSettingSliderUI : MonoBehaviour
    {
        [SerializeField] private FloatSetting floatSetting;

        private Slider slider;

        void Awake()
        {
            slider = GetComponent<Slider>();
            slider.maxValue = floatSetting.Limit.Max;
            slider.minValue = floatSetting.Limit.Min;
        }

        private void OnEnable()
        {
            slider.value = floatSetting.Value;
            slider.onValueChanged.AddListener(value => { floatSetting.SetValue(value); });
            floatSetting.OnValueChanged += value => slider.value = value;
        }

        void OnDisable()
        {
            slider.onValueChanged.RemoveListener(value => { floatSetting.SetValue(value); });
            floatSetting.OnValueChanged -= value => slider.value = value;
        }
    }
}
