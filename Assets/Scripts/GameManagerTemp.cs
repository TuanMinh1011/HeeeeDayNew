using UnityEngine;

public class GameManagerTemp : MonoBehaviour
{
    public void ActionPLanted()
    {
        CoinsChangedEvent coinsChangedEvent = new CoinsChangedEvent(1);
        EventManager.Instance.TriggerEvent(coinsChangedEvent);
    }
}
