using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WheaterControl : MonoBehaviour
{
    [SerializeField] string uriApi = "https://goweather.herokuapp.com/weather/";
    [SerializeField] TMP_InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        inputField.onEndEdit.AddListener(UpdateWeather);
    }

    private void UpdateWeather(string city)
    {
        StartCoroutine(WebRequester.GetRequest<WeatherData>($"{uriApi}{city}", UseWeatherData));
    }

    private void UseWeatherData(WeatherData data)
    {
        Debug.Log(data.ToString());
    }
}