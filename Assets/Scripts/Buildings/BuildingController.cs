using Events;
using Histhack.Core.SaveLoadSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingController : Singleton<BuildingController>
{
    [SerializeField]
    private BuildingScriptableObject researchCenterData;

    [SerializeField]
    private BuildingScriptableObject rocketPlatformData;

    [SerializeField]
    private BuildingScriptableObject observatoryData;

    [SerializeField]
    private BuildingScriptableObject recrutationCenterData;

    [SerializeField]
    private BuildingScriptableObject schoolingSectionData;

    [SerializeField]
    private Button LaunchSateliteButton;

    [SerializeField]
    private Button ReaserchButton;

    [SerializeField]
    private BuildingScriptableObject reseachFacility;

    [SerializeField]
    private BuildingScriptableObject rocketLauncher;

    [SerializeField]
    private List<BuildingSocket> sockets = new List<BuildingSocket>();

    [SerializeField]
    private TutorialStepsData researchQuest;

    [SerializeField]
    private TutorialStepsData rocketQuest;

    public Action<BuildingScriptableObject> OnBuild;

    public void CallOnBuild(BuildingScriptableObject buildingData) {
        if (OnBuild != null)
            OnBuild.Invoke(buildingData);
    }

    public Action<BuildingScriptableObject> OnSell;

    public void CallOnSell(BuildingScriptableObject buildingData)
    {
        if (OnSell != null)
            OnSell.Invoke(buildingData);
    }


    private buildingFunctionality lastBuilding;

    public buildingFunctionality LastBuilding { get => lastBuilding; set => lastBuilding = value; }

    private void OnEnable()
    {
        OnBuild += CheckIfImportantBuilding;
        OnSell += CheckIfSellImportantBuilding;
        PlayerEvents.Instance.OnSaveGame += SaveData;
        PlayerEvents.Instance.OnLoadGame += LoadData;
    }

    private void OnDisable()
    {
        OnBuild -= CheckIfImportantBuilding;
        OnSell -= CheckIfSellImportantBuilding;
        if(PlayerEvents.Instance != null)
        {
            PlayerEvents.Instance.OnSaveGame -= SaveData;
            PlayerEvents.Instance.OnLoadGame -= LoadData;
        }
    }

    private void SaveData()
    {
        List<bool> hasBuildings = new List<bool>();
        List<int> whatLevel = new List<int>();

        for(int i=0; i<sockets.Count; i++)
        {
            if (sockets[i].BuildingOnSocket != null)
            {
                hasBuildings.Add(true);
                if (sockets[i].BuildingOnSocket.CurrentLevel != null)
                    whatLevel.Add(GetLevel(sockets[i].BuildingOnSocket.CurrentLevel.reaserchLevel));
                else
                    whatLevel.Add(-1);
            }
            else
            {
                hasBuildings.Add(false);
                whatLevel.Add(-1);
            }
        }

        SaveSystem.Save<List<bool>>(hasBuildings, "SavedBuildingsInfo",SaveDirectories.Level);
        SaveSystem.Save<List<int>>(whatLevel, "SavedBuildingsLevel", SaveDirectories.Level);
    }

    private void LoadData()
    {
        List<int> whatLevel = new List<int>();
        List<bool> hasBuildings = new List<bool>();

        if (SaveSystem.CheckIfFileExists("SavedBuildingsInfo",SaveDirectories.Level))
        {
            hasBuildings = SaveSystem.Load<List<bool>>("SavedBuildingsInfo",null,SaveDirectories.Level);
        }

        if(SaveSystem.CheckIfFileExists("SavedBuildingsLevel", SaveDirectories.Level))
        {
            whatLevel = SaveSystem.Load<List<int>>("SavedBuildingsLevel",null, SaveDirectories.Level);
        }

        for(int i=0; i< hasBuildings.Count; i++)
        {
            if (hasBuildings[i] == true)
            {
                sockets[i].BuildBuilding();

                if (whatLevel[i] != -1)
                {
                    sockets[i].BuildingOnSocket.ChangeCurrentLevel(whatLevel[i]);
                }
            }
        }
    }

    private int GetLevel(ReaserchLevel level)
    {
        switch (level) {
            case ReaserchLevel.L1:
                return 1;
            case ReaserchLevel.L2:
                return 2;
            case ReaserchLevel.L3:
                return 3;
        }

        return -1;
    }

    private ReaserchLevel GetLevel(int level)
    {
        switch (level)
        {
            case 1:
                return ReaserchLevel.L1;
            case 2:
                return ReaserchLevel.L2;
            case 3:
                return ReaserchLevel.L3;
        }
        return ReaserchLevel.L1;
    }

    private void CheckIfSellImportantBuilding(BuildingScriptableObject data)
    {
        if (data == reseachFacility)
        {
            ReaserchButton.gameObject.SetActive(false);
        }
        else if (data == rocketLauncher)
        {
            LaunchSateliteButton.gameObject.SetActive(false);
        }
    }

    private void CheckIfImportantBuilding(BuildingScriptableObject data)
    {
        if(data == reseachFacility)
        {
            if(TutorialController.Instance.TutorialGoing)
            {
                TutorialController.Instance.FinishQuest(researchQuest);
            }
            ReaserchButton.gameObject.SetActive(true);
        }
        else if(data == rocketLauncher)
        {
            if (TutorialController.Instance.TutorialGoing)
            {
                TutorialController.Instance.FinishQuest(rocketQuest);
            }
            LaunchSateliteButton.gameObject.SetActive(true);
        }
    }

    public BuildingScriptableObject GetBuildingData(BuildingTypes types)
    {
        switch (types)
        {
            case BuildingTypes.ResearchCenter:
                return researchCenterData;
            case BuildingTypes.RocketPlatform:
                return rocketPlatformData;
            case BuildingTypes.Observatory:
                return observatoryData;
            case BuildingTypes.RecrutationCenter:
                return recrutationCenterData;
            case BuildingTypes.SchoolingSection:
                return schoolingSectionData;
        }
        return null;
    }

    public bool DisplayBuildingInfo(buildingFunctionality currentBuilding)
    {

        ClosePopups.Instance.CloseWithoutOne(this);

        if(lastBuilding == null)
        {
            lastBuilding = currentBuilding;
            return true;
        }
        else if(lastBuilding == currentBuilding)
        {
            lastBuilding = null;
            return false;
        }
        else
        {
            lastBuilding.HideBuilding();
            lastBuilding = currentBuilding;
            return true;
        }
    }

    public void HideBuildingInfo()
    {
        if (lastBuilding == null)
            return;
        lastBuilding.HideBuilding();
        lastBuilding = null;
    }

}
public enum BuildingTypes
{
    ResearchCenter,
    RocketPlatform,
    Observatory,
    RecrutationCenter,
    SchoolingSection
}