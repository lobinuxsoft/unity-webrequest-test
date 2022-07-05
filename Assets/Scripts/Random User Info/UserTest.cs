using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserTest : MonoBehaviour
{
    [SerializeField] string uri = "https://randomuser.me/api";
    [SerializeField] RawImage picture;

    public void UpdateUserInfo()
    {
        StartCoroutine(WebRequester.GetRequest<UserInfo>(uri, UseInfo));
    }

    private void UseInfo(UserInfo info)
    {
        StartCoroutine(WebRequester.GetImage(info.results[0].picture.large, UseImage));
    }

    private void UseImage(Texture texture)
    {
        picture.texture = texture;
    }
}