using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LandController : MonoBehaviour
{
    public int LandID;
    
    private Button _landButton;
    private TextMeshProUGUI _landText;

    private void Awake()
    {
        _landText = GetComponentInChildren<TextMeshProUGUI>();
        _landButton = GetComponent<Button>();
        _landButton.onClick.AddListener(Planted);
    }

    public void SetLandID(int id)
    {
        LandID = id;
    }

    public void Planted()
    {
        EventManager.Instance.TriggerEvent(new LandPlantedAddEvent(LandID));
    }

    public void PlantedSuccess()
    {
        _landText.text = "Planted";
        _landButton.interactable = false;
    }
}
