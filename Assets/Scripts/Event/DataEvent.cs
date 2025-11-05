using UnityEngine;

public abstract class DataEvent : GameEvent { }

public class LoadDataEvent : DataEvent
{
    public User User;
    public LoadDataEvent(User user)
    {
        User = user;
    }
}

public class LandSpaceSucceeded: DataEvent
{
    public int Amount;
    public LandSpaceSucceeded(int amount)
    {
        Amount = amount;
    }
}

public class LandPlantedSucceeded: DataEvent
{
    public int LandID;
    public int AmountSpace;
    public int AmountPlanted;
    public LandPlantedSucceeded(int landID, int amountSpace, int amountPlanted)
    {
        LandID = landID;
        AmountSpace = amountSpace;
        AmountPlanted = amountPlanted;
    }
}
