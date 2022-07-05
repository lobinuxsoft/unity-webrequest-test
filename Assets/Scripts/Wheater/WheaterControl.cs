using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WheaterControl : MonoBehaviour
{
    [SerializeField] string uriApi = "https://goweather.herokuapp.com/weather/";
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TextMeshProUGUI textMesh;

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
        if(!string.IsNullOrEmpty(data.description) && !string.IsNullOrEmpty(data.temperature) && !string.IsNullOrEmpty(data.wind))
        {
            int temperature = int.Parse(data.temperature.Split(' ')[0]);
            int windSpeed = int.Parse(data.wind.Split(' ')[0]);

            textMesh.text = $"{data.description}" +
                            $"\n{temperature}" +
                            $"\n{windSpeed}";
        }
        else
        {
            textMesh.text = "This location not exist";
        }
    }
}