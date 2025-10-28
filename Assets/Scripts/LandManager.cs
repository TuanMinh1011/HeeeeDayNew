using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LandManager : MonoBehaviour
{
    [SerializeField] private Transform LandParent;
    [SerializeField] private GameObject landPrefab;

    [SerializeField] private Dictionary<int, LandController> landDictionary = new Dictionary<int, LandController>();

    private void Start()
    {
        EventManager.Instance.AddListener<LandPlantedAddEvent>(OnLandPlantedAdded);
    }

    public void AddLand()
    {
        GameObject land = Instantiate(landPrefab);
        land.GetComponent<RectTransform>().SetParent(LandParent, false);
        land.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(800, -800), Random.Range(337, -337));
        land.GetComponent<LandController>().SetLandID(landDictionary.Count);
        landDictionary.Add(landDictionary.Count, land.GetComponent<LandController>());
        EventManager.Instance.TriggerEvent(new LandSpaceAddEvent(1));
    }

    private void OnLandPlantedAdded(LandPlantedAddEvent info)
    {
        landDictionary[info.LandID].PlantedSuccess();
    }
}
