using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsText;
    [SerializeField] private TextMeshProUGUI _landSpaceText;
    [SerializeField] private TextMeshProUGUI _landPlantedText;

    private int _cointAmount;
    private int _landSpaceAmount;
    private int _landPlantedAmount;

    private void Start()
    {
        EventManager.Instance.AddListener<CoinsChangedEvent>(CoinsTextChanged);
        EventManager.Instance.AddListener<LandSpaceAddEvent>(LandSpaceChanged);
        EventManager.Instance.AddListener<LandPlantedAddEvent>(LandPlantedChanged);
    }

    private void CoinsTextChanged(CoinsChangedEvent info)
    {
        _cointAmount += info.Amount;

        _coinsText.text = _cointAmount.ToString();
    }

    private void LandSpaceChanged(LandSpaceAddEvent info)
    {
        _landSpaceAmount += info.Amount;

        _landSpaceText.text = _landSpaceAmount.ToString();
    }

    private void LandPlantedChanged(LandPlantedAddEvent info)
    {
        _landPlantedAmount += info.Amount;
        _landSpaceAmount -= info.Amount;

        _landPlantedText.text = _landPlantedAmount.ToString();
        _landSpaceText.text = _landSpaceAmount.ToString();
    }
}
