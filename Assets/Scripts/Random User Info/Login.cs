using System;

[Serializable]
public struct Login
{
    public string uuid;
    public string username;
    public string password;
    public string salt;
    public string md5;
    public string sha1;
    public string sha256;
}
