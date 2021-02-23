using System;
using UnityEngine;


public class myGUI : MonoBehaviour
{
    public float Health = 150.0f;
    public float MaxHealth = 200.0f;
    public GUISkin test;
    public Color myColor;
    public float sliderMinValueRGB = 20.0f;
    private Rect labelHPRect, valueHPRect;
    private string _healthString;

    private void Start()
    {
        _healthString = Math.Truncate(Health).ToString();
        labelHPRect = new Rect(50 + (MaxHealth - 50) / 2 - _healthString.Length / 2, 20, 200, 50);
        valueHPRect = new Rect(50, 50, Health, 50);
        myColor = RGBSlider(new Rect(50, 100, 200, 20), myColor, sliderMinValueRGB);
        sliderMinValueRGB = RowSlider(new Rect(50, 160, 200, 20), 30.0f, sliderMinValueRGB, 200.0f, "rgbA");
    }

    private void OnGUI()
    {
        GUI.skin = test;
        _healthString = Math.Truncate(Health).ToString();
        GUI.Label(labelHPRect, _healthString);

        Health = GUI.HorizontalSlider(valueHPRect, Health, 0.0f, MaxHealth);
        myColor = RGBSlider(new Rect(50, 100, 200, 20), myColor, sliderMinValueRGB);
        sliderMinValueRGB = RowSlider(new Rect(50, 160, 200, 20), 30.0f, sliderMinValueRGB, 200.0f, "rgbA");
    }

    Color RGBSlider(Rect screenRect, Color rgb, float minValue)
    {
        rgb.r = RowSlider(screenRect, rgb.r, minValue, 200.0f, "Red");
        screenRect.y += 20;
        rgb.g = RowSlider(screenRect, rgb.g, minValue, 200.0f, "Green");
        screenRect.y += 20;
        rgb.b = RowSlider(screenRect, rgb.b, minValue, 200.0f, "Blue");
        return rgb;
    }

    float RowSlider(Rect screenRect, float sliderValue, float sliderMinValue, float sliderMaxValue, string labelText)
    {
        GUI.Label(screenRect, labelText);
        screenRect.x += 70;
        sliderValue = GUI.HorizontalSlider(screenRect, sliderValue, sliderMinValue, sliderMaxValue);
        if (sliderValue <= sliderMinValue)
            sliderValue = sliderMinValue;
        return sliderValue;
    }
}