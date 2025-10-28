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
    public int Amount;
    public LandSpaceAddEvent(int amount)
    {
        Amount = amount;
    }
}

public class LandPlantedAddEvent: GameEvent
{
    public int Amount;
    public int LandID;
    public LandPlantedAddEvent(int amount, int landID)
    {
        Amount = amount;
        LandID = landID;
    }
}
