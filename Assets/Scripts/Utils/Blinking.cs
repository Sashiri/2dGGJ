using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Blinking : MonoBehaviour
{
    private float blinkDuration = 0.3f;
    private float blinkstartTime;
    private float blinkTime;
    private TextMeshProUGUI text;
    private Color startColor;
    private bool IsFading;

    private void Awake()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
        startColor = text.color;
    }
    private void Update()
    {
        if (IsFading)
        {
            StartFading();
        } else startAppearing();
    }

    private void StartFading()
    {
        float currrentAlpha = text.color.a;
        blinkstartTime = Time.time;
        blinkTime = Time.time - blinkstartTime;
        Color newColor = new Color(1, 1, 1, Mathf.Lerp(currrentAlpha, 0f, Time.deltaTime / blinkDuration));
        text.color = newColor;
        if( newColor.a < 0.05)
        {
            IsFading = !IsFading;
        }
    }

    private void startAppearing()
    {
        float currrentAlpha = text.color.a;
        blinkstartTime = Time.time;
        blinkTime = Time.time - blinkstartTime;
        Color newColor = new Color(1, 1, 1, Mathf.Lerp(currrentAlpha, 1.0f, Time.deltaTime / blinkDuration));
        text.color = newColor;
        if (newColor.a > 0.95)
        {
            IsFading = !IsFading;
        }
    }

}
