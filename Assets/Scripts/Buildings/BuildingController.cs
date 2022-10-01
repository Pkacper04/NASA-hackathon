using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    private buildingFunctionality lastBuilding;

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

    public void SellBuilding()
    {
        // do uzupelnienia
    }

    public bool DisplayBuildingInfo(buildingFunctionality currentBuilding)
    {
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