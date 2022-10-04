using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResearchData")]

public class ResearchData : ScriptableObject
{
    public string ResearchName;
    public int ResearchCost;
    public int BuildingCost;
    public string ResearchDescription;
    public bool isPurchased = false;
    public ResearchData previousUpgrade = null;
    public ResearchData nextUpgrade = null;
    public TypeOfReaserch typeOfReaserch = TypeOfReaserch.Building;
    public SateliteData sateliteData = SateliteData.ReaserchAmount;
    public ReaserchLevel reaserchLevel = ReaserchLevel.L1;
}

public enum TypeOfReaserch
{
    Building,
    Main,
    Satelite
}

public enum SateliteData
{
    ReaserchAmount,
    ReaserchLength,
    ReaserchRarity
}

public enum ReaserchLevel
{
    L1,
    L2,
    L3
}
