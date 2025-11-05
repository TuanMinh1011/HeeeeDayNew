using UnityEngine;

public enum PlantType
{
    Space,
    Tomato,
    BlueBerry,
    Strawberry,
    Cow
}

public class User
{
    public string Username;
    public int Coins;
    public int Level; 
    public Land[] Lands;
}

public class Land
{
    public int LandID;
    public string LandName;
    public bool IsPlanted;
    public Vector2Data LandPosition;
    public Plant CurrentPlant;
}

public class Plant
{
    public PlantType PlantType;
    public string PlantName;
    public int GrowthTime; // in seconds
    public int NumberInLifeCycle;
    public int CurrentCycle;
}







public class Vector2Data
{
    public float x;
    public float y;

    public Vector2Data(float x, float y)
    {
        this.x = x;
        this.y = y;
    }
}