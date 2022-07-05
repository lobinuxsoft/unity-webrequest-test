using System;

[Serializable]
public struct Location
{
    public Street street;
    public string city;
    public string state;
    public string country;
    public int postcode;
    public Coordinates coordinates;
    public Timezone timezone;
}
