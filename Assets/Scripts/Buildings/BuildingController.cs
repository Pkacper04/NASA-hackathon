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
    }

    private void OnDisable()
    {
        OnBuild -= CheckIfImportantBuilding;
        OnSell -= CheckIfSellImportantBuilding;
    }

    private void Start()
    {
        ReaserchButton.gameObject.SetActive(false);
        LaunchSateliteButton.gameObject.SetActive(false);
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
            ReaserchButton.gameObject.SetActive(true);
        }
        else if(data == rocketLauncher)
        {
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
        Debug.Log("Klikniecei");
        BuildingPanelController.Instance.DeInit();
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