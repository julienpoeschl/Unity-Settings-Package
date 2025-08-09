using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class SliderValueUI : MonoBehaviour
{
    [SerializeField] private Slider slider;

    [SerializeField] private SliderValueSuffix suffix;
    [SerializeField] private bool roundValue;
    [SerializeField] private float multiplyValue = 1;

    private TextMeshProUGUI sliderValueText;

    void Awake()
    {
        sliderValueText = GetComponent<TextMeshProUGUI>();
    }

    void OnEnable()
    {
        UpdateValue(slider.value);
        slider.onValueChanged.AddListener(UpdateValue);
    }

    void OnDisable()
    {
        slider.onValueChanged.RemoveListener(UpdateValue);
    }

    void UpdateValue(float value)
    {
        value *= multiplyValue;
        sliderValueText.text = (roundValue ? Mathf.Round(value) : value).ToString() + GetSuffix();
    }

    string GetSuffix()
    {
        return suffix switch
        {
            SliderValueSuffix.Percent => "%",
            _ => ""
        };
    }
}

public enum SliderValueSuffix
{
    None,
    Percent

}
