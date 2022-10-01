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

}
public enum BuildingTypes
{
    ResearchCenter,
    RocketPlatform,
    Observatory,
    RecrutationCenter,
    SchoolingSection
}