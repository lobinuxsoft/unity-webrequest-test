using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;


public static class WebRequester
{
    // Api request samples https://github.com/public-apis/public-apis
    // https://apipheny.io/free-api/
    // https://api.le-systeme-solaire.net/en/

    public static IEnumerator GetRequest<T>(string uri, Action<T> callback)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError($"Error: {webRequest.error}");
                    break;

                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError($"HTTP Error: {webRequest.error}");
                    break;

                case UnityWebRequest.Result.Success:
                    T userInfo = JsonUtility.FromJson<T>(webRequest.downloadHandler.text);
                    callback?.Invoke(userInfo);
                    break;
            }
        }
    }

    public static IEnumerator GetImage(string uri, Action<Texture> callback)
    {
        using (UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError($"Error: {webRequest.error}");
                    break;

                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError($"HTTP Error: {webRequest.error}");
                    break;

                case UnityWebRequest.Result.Success:
                    callback?.Invoke(DownloadHandlerTexture.GetContent(webRequest));
                    break;
            }
        }
    }
}