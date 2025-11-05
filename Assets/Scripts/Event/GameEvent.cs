using UnityEngine;

public abstract class GameEvent { }

public class CoinsChangedEvent: GameEvent
{
    public int Amount;
    public CoinsChangedEvent(int amount)
    {
        Amount = amount;
    }
}

public class LandSpaceAddEvent: GameEvent
{
    public int LandID;
    public int Amount;
    public Vector2 Position;

    public LandSpaceAddEvent(int landId, int amount, Vector2 position)
    {
        LandID = landId;
        Amount = amount;
        Position = position;
    }
}

public class LandPlantedAddEvent: GameEvent
{
    public int LandID;

    public LandPlantedAddEvent(int landID)
    {
        LandID = landID;
    }
}

//public class LoadDataEvent : GameEvent
//{
//    public User User;
//    public LoadDataEvent(User user) 
//    {
//        User = user;
//    }
//}
