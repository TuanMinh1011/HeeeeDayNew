using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public User CurrentUser;
    private JsonManager jsonManager;

    private void OnEnable()
    {
        EventManager.Instance.AddListener<LandSpaceAddEvent>(LandSpaceChanged);
        EventManager.Instance.AddListener<LandPlantedAddEvent>(LandPlantedChanged);
    }

    private void Awake()
    {
        jsonManager = GetComponent<JsonManager>();
    }

    private void Start()
    {
        LoadDataUser();
    }

    private void LandSpaceChanged(LandSpaceAddEvent info)
    {
        if (info.Amount == 1)
        {
            Land land = new Land
            {
                LandID = info.LandID,
                LandName = "Land " + (info.LandID + 1),
                IsPlanted = false,
                LandPosition = new Vector2Data(info.Position.x, info.Position.y),
                CurrentPlant = null
            };

            List<Land> landList = CurrentUser.Lands.ToList();
            landList.Add(land);
            CurrentUser.Lands = landList.ToArray();

            int landSpaces = CurrentUser.Lands.Count(x => !x.IsPlanted);

            jsonManager.SaveUser(CurrentUser);
            EventManager.Instance.TriggerEvent(new LandSpaceSucceeded(landSpaces));
        }
    }

    private void LandPlantedChanged(LandPlantedAddEvent info)
    {
        CurrentUser.Lands.FirstOrDefault(land => land.LandID == info.LandID).IsPlanted = true;
        jsonManager.SaveUser(CurrentUser);

        int landSpaces = CurrentUser.Lands.Count(x => !x.IsPlanted);
        int landPlanted = CurrentUser.Lands.Count(x => x.IsPlanted);

        EventManager.Instance.TriggerEvent(new LandPlantedSucceeded(info.LandID, landSpaces, landPlanted));
    }

    private void LoadDataUser()
    {
        CurrentUser = jsonManager.LoadUser();
        EventManager.Instance.TriggerEvent(new LoadDataEvent(CurrentUser));
    }
}
