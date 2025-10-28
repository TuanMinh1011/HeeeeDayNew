using UnityEngine;

public class DataManager : MonoBehaviour
{
    public User CurrentUser;
    private JsonManager jsonManager;

    private void Awake()
    {
        jsonManager = GetComponent<JsonManager>();
    }

    private void Start()
    {
        LoadDataUser();
    }

    private void LoadDataUser()
    {
        CurrentUser = jsonManager.LoadUser();
    }
}
