using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LandManager : MonoBehaviour
{
    [SerializeField] private Transform LandParent;
    [SerializeField] private GameObject landPrefab;

    [SerializeField] private Dictionary<int, LandController> landDictionary = new Dictionary<int, LandController>();

    private void OnEnable()
    {
        EventManager.Instance.AddListener<LoadDataEvent>(OnLoadDataLand);
        EventManager.Instance.AddListener<LandPlantedSucceeded>(OnLandPlantedAdded);
    }

    private void OnLoadDataLand(LoadDataEvent info)
    {
        foreach (var land in info.User.Lands)
        {
            GameObject landObj = Instantiate(landPrefab);
            landObj.GetComponent<RectTransform>().SetParent(LandParent, false);
            landObj.GetComponent<RectTransform>().anchoredPosition = new Vector2(land.LandPosition.x, land.LandPosition.y);
            landObj.GetComponent<LandController>().SetLandID(land.LandID);
            landDictionary.Add(land.LandID, landObj.GetComponent<LandController>());
            if (land.IsPlanted)
            {
                landDictionary[land.LandID].PlantedSuccess();
            }
        }
    }

    public void AddLand()
    {
        GameObject land = Instantiate(landPrefab);
        LandController landController = land.GetComponent<LandController>();
        Vector2 landPosition = new Vector2(Random.Range(800, -800), Random.Range(337, -337));

        land.GetComponent<RectTransform>().SetParent(LandParent, false);
        land.GetComponent<RectTransform>().anchoredPosition = landPosition;
        landController.SetLandID(landDictionary.Count);
        landDictionary.Add(landDictionary.Count, landController);

        EventManager.Instance.TriggerEvent(new LandSpaceAddEvent(landController.LandID, 1, landPosition));
    }

    private void OnLandPlantedAdded(LandPlantedSucceeded info)
    {
        landDictionary[info.LandID].PlantedSuccess();
    }
}
