using System.Linq;
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

    private void OnEnable()
    {
        EventManager.Instance.AddListener<CoinsChangedEvent>(CoinsTextChanged);
        EventManager.Instance.AddListener<LandSpaceSucceeded>(LandSpaceChanged);
        EventManager.Instance.AddListener<LandPlantedSucceeded>(LandPlantedChanged);

        EventManager.Instance.AddListener<LoadDataEvent>(LoadData);
    }

    private void LoadData(LoadDataEvent info)
    {
        _cointAmount = info.User.Coins;
        _landSpaceAmount = info.User.Lands.Count(x => !x.IsPlanted);
        _landPlantedAmount = info.User.Lands.Count(x => x.IsPlanted);

        _coinsText.text = _cointAmount.ToString();
        _landSpaceText.text = _landSpaceAmount.ToString();
        _landPlantedText.text = _landPlantedAmount.ToString();
    }

    private void CoinsTextChanged(CoinsChangedEvent info)
    {
        _cointAmount += info.Amount;

        _coinsText.text = _cointAmount.ToString();
    }

    private void LandSpaceChanged(LandSpaceSucceeded info)
    {
        _landSpaceAmount = info.Amount;

        _landSpaceText.text = _landSpaceAmount.ToString();
    }

    private void LandPlantedChanged(LandPlantedSucceeded info)
    {
        _landPlantedAmount = info.AmountPlanted;
        _landSpaceAmount = info.AmountSpace;

        _landPlantedText.text = _landPlantedAmount.ToString();
        _landSpaceText.text = _landSpaceAmount.ToString();
    }
}
